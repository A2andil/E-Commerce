import { Injectable, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { IPagination } from '../shared/models/pagination'

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

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl + 'products?PageSize=50');
  }
}
