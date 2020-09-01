import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands: IBrand[];
  Types: IType[];
  brandIdSelected: number = 0;
  typeIdSelected: number = 0;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.typeIdSelected, this.brandIdSelected).subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }

  getBrands() {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
      //console.log(response);
    }, error=> {
      console.log(error);
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe(response => {
      this.Types = [{id: 0, name: 'All'}, ...response];
    }, error=> {
      console.log(error);
    })
  }

  onBrandIdSelected(id: number) {
    this.brandIdSelected = id;
    this.getProducts();
    console.log(id);
  }

  onTypeIdSelected(id: number) {
    this.typeIdSelected = id;
    this.getProducts();
  }

}
