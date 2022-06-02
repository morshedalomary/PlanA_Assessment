import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ICategory } from '../model/ICategory';
import { CategoryService } from '../services/category.service';
import { ActivatedRoute, LoadChildren, Router } from '@angular/router';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  ELEMENT_DATA: ICategory[] = [];
  loadData: boolean = true;
  numberCategory: number = 0;
  displayedColumns: string[] = ['Name', 'operation'];
  dataSource: any;
  @ViewChild(MatPaginator, { static: false }) set paginator(matPaginator: MatPaginator) {
  }
  @ViewChild(MatSort, { static: false }) set sort(sort: MatSort) {
  }
  constructor(private _location : Location ,  private _router: Router, private _categoryService: CategoryService) {
    this._categoryService.getAllCategoryList().subscribe(
      data => {
        //  console.log("Data" + JSON.stringify(data))
        this.loadData = false;
        this.ELEMENT_DATA = data;

        this.numberCategory = this.ELEMENT_DATA.length;

        this.dataSource = this.ELEMENT_DATA



        this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;



      }
    );
}
  deleteCategory(element: any) {
    this._categoryService.DeleteCategory(element.id).subscribe(data => {

      this.refreshCategoryList();
    })

  }
  refreshCategoryList() {
    this._categoryService.getAllCategoryList().subscribe(
      data => {
        //console.log("Data" + JSON.stringify(data))
        this.loadData = false;
        this.ELEMENT_DATA = data;

        this.numberCategory = this.ELEMENT_DATA.length;

        this.dataSource = this.ELEMENT_DATA



        this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;



      }
    );
  }
  addCategory() {
    this._router.navigateByUrl('/addcategory/');
  }
  updateCategory(element: any) {
    this._router.navigateByUrl('/addcategory/' + element['id']);
  }
  ngOnInit(): void {
  }
  back() {
    this._location.back();
  }
}
