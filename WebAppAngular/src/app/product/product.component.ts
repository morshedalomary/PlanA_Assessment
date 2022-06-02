import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { IProduct } from '../model/IProduct';
import { ProductService } from '../services/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  ELEMENT_DATA: IProduct[] = [];
  //dataSource: any;
  //displayedColumns: any;
  loadData: boolean = true;
  numberProduct: number = 0;
  displayedColumns: string[] = ['Image', 'Title', 'Description', 'Price', 'Number_of_Views', 'Dietary_flags'];
  dataSource: any;
  searchText: string = '';
  @ViewChild(MatPaginator, { static: false }) set paginator(matPaginator: MatPaginator) {
  }
  @ViewChild(MatSort, { static: false }) set sort(sort: MatSort) {
  }
 
  constructor(private _location : Location, private _router: Router, private _productService: ProductService) {
    this._productService.getAllProductList().subscribe(
      data => {
        this.loadData = false;
        this.ELEMENT_DATA = data;

        this.numberProduct = this.ELEMENT_DATA.length;

      this.dataSource  = this.ELEMENT_DATA


        this.displayedColumns = ['Image', 'Title', 'Description', 'Price', 'Number_of_Views', 'Dietary_flags', 'operation'];

        this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
        
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;



      }
    );
}
  onKeySearch() {
    console.log(this.searchText)
    this._productService.getSearchProductList(this.searchText).subscribe(
      data => {
        this.loadData = false;
        this.ELEMENT_DATA = data;

        this.numberProduct = this.ELEMENT_DATA.length;

        this.dataSource = this.ELEMENT_DATA


        this.displayedColumns = ['Image', 'Title', 'Description', 'Price', 'Number_of_Views', 'Dietary_flags', 'operation'];

        this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;



      }
    );}
  ngOnInit(): void {

  

  }

  deleteProduct(element: any  ) {
    this._productService.DeleteProduct(element.id).subscribe(data => {
     
      this.refreshProductList();
    })

  }

  refreshProductList() {
    this._productService.getAllProductList().subscribe(
      data => {
        this.loadData = false;
        this.ELEMENT_DATA = data;

        this.numberProduct = this.ELEMENT_DATA.length;

        this.dataSource = this.ELEMENT_DATA


        this.displayedColumns = ['Image', 'Title', 'Description', 'Price', 'Number_of_Views', 'Dietary_flags', 'operation'];

        this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;



      }
    );
}
  addProduct() {
    this._router.navigateByUrl('/addproduct/' );
  }
  updateProduct(element: any) {
    this._router.navigateByUrl('/addproduct/' + element['id']);
  }
  back() {
    this._location.back();
  }
 

}
