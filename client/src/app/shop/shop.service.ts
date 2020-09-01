import { Injectable, NgModule } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
@NgModule({
  providers: [

  ],
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(typeId?: number, brandId?: number) {
    let params = new HttpParams();
    if (typeId != 0) {
      params.append('typeId', typeId.toString());
    }

    if (brandId != 0) {
      params.append('brandId', brandId.toString());
      console.log(brandId);
    }

    return this.http.get<IPagination>(this.baseUrl + 'products?pageSize=50', {observe: 'response', params})
        .pipe(
          map(response => 
            {
              return response.body;
            })
        );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
