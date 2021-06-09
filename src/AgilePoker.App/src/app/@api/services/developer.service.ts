import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Developer } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class DeveloperService implements IPagableService<Developer> {

  uniqueIdentifierName: string = "developerId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Developer>> {
    return this._client.get<EntityPage<Developer>>(`${this._baseUrl}api/developer/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Developer[]> {
    return this._client.get<{ developers: Developer[] }>(`${this._baseUrl}api/developer`)
      .pipe(
        map(x => x.developers)
      );
  }

  public getById(options: { developerId: string }): Observable<Developer> {
    return this._client.get<{ developer: Developer }>(`${this._baseUrl}api/developer/${options.developerId}`)
      .pipe(
        map(x => x.developer)
      );
  }

  public remove(options: { developer: Developer }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/developer/${options.developer.developerId}`);
  }

  public create(options: { developer: Developer }): Observable<{ developer: Developer }> {
    return this._client.post<{ developer: Developer }>(`${this._baseUrl}api/developer`, { developer: options.developer });
  }
  
  public update(options: { developer: Developer }): Observable<{ developer: Developer }> {
    return this._client.put<{ developer: Developer }>(`${this._baseUrl}api/developer`, { developer: options.developer });
  }
}
