import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Invite } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class InviteService implements IPagableService<Invite> {

  uniqueIdentifierName: string = "inviteId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Invite>> {
    return this._client.get<EntityPage<Invite>>(`${this._baseUrl}api/invite/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Invite[]> {
    return this._client.get<{ invites: Invite[] }>(`${this._baseUrl}api/invite`)
      .pipe(
        map(x => x.invites)
      );
  }

  public getById(options: { inviteId: string }): Observable<Invite> {
    return this._client.get<{ invite: Invite }>(`${this._baseUrl}api/invite/${options.inviteId}`)
      .pipe(
        map(x => x.invite)
      );
  }

  public remove(options: { invite: Invite }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/invite/${options.invite.inviteId}`);
  }

  public create(options: { invite: Invite }): Observable<{ invite: Invite }> {
    return this._client.post<{ invite: Invite }>(`${this._baseUrl}api/invite`, { invite: options.invite });
  }
  
  public update(options: { invite: Invite }): Observable<{ invite: Invite }> {
    return this._client.put<{ invite: Invite }>(`${this._baseUrl}api/invite`, { invite: options.invite });
  }
}
