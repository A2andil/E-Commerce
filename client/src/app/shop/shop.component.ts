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
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelect = 'name';
  sortOptions = [
    { name : 'Alphabetical', value: 'name'},
    { name : 'Price: Low to High', value: 'priceAsc'},
    { name : 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.typeIdSelected, this.brandIdSelected, this.sortSelect).subscribe(response => {
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
    //console.log(id);
  }

  onTypeIdSelected(id: number) {
    this.typeIdSelected = id;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.sortSelect = sort;
    this.getProducts();
  }

}
