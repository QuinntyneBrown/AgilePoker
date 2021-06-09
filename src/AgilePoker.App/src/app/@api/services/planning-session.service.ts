import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { PlanningSession } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class PlanningSessionService implements IPagableService<PlanningSession> {

  uniqueIdentifierName: string = "planningSessionId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<PlanningSession>> {
    return this._client.get<EntityPage<PlanningSession>>(`${this._baseUrl}api/planningSession/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<PlanningSession[]> {
    return this._client.get<{ planningSessions: PlanningSession[] }>(`${this._baseUrl}api/planningSession`)
      .pipe(
        map(x => x.planningSessions)
      );
  }

  public getById(options: { planningSessionId: string }): Observable<PlanningSession> {
    return this._client.get<{ planningSession: PlanningSession }>(`${this._baseUrl}api/planningSession/${options.planningSessionId}`)
      .pipe(
        map(x => x.planningSession)
      );
  }

  public remove(options: { planningSession: PlanningSession }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/planningSession/${options.planningSession.planningSessionId}`);
  }

  public create(options: { planningSession: PlanningSession }): Observable<{ planningSession: PlanningSession }> {
    return this._client.post<{ planningSession: PlanningSession }>(`${this._baseUrl}api/planningSession`, { planningSession: options.planningSession });
  }
  
  public update(options: { planningSession: PlanningSession }): Observable<{ planningSession: PlanningSession }> {
    return this._client.put<{ planningSession: PlanningSession }>(`${this._baseUrl}api/planningSession`, { planningSession: options.planningSession });
  }
}
