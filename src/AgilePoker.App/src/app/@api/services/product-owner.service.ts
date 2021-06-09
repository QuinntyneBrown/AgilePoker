import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ProductOwner } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProductOwnerService implements IPagableService<ProductOwner> {

  uniqueIdentifierName: string = "productOwnerId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ProductOwner>> {
    return this._client.get<EntityPage<ProductOwner>>(`${this._baseUrl}api/productOwner/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ProductOwner[]> {
    return this._client.get<{ productOwners: ProductOwner[] }>(`${this._baseUrl}api/productOwner`)
      .pipe(
        map(x => x.productOwners)
      );
  }

  public getById(options: { productOwnerId: string }): Observable<ProductOwner> {
    return this._client.get<{ productOwner: ProductOwner }>(`${this._baseUrl}api/productOwner/${options.productOwnerId}`)
      .pipe(
        map(x => x.productOwner)
      );
  }

  public remove(options: { productOwner: ProductOwner }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/productOwner/${options.productOwner.productOwnerId}`);
  }

  public create(options: { productOwner: ProductOwner }): Observable<{ productOwner: ProductOwner }> {
    return this._client.post<{ productOwner: ProductOwner }>(`${this._baseUrl}api/productOwner`, { productOwner: options.productOwner });
  }
  
  public update(options: { productOwner: ProductOwner }): Observable<{ productOwner: ProductOwner }> {
    return this._client.put<{ productOwner: ProductOwner }>(`${this._baseUrl}api/productOwner`, { productOwner: options.productOwner });
  }
}
