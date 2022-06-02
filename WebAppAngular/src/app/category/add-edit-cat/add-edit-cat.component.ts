import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../services/category.service';
import { ProductService } from '../../services/product.service';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { PopUpDialog } from '../../pop-up-dialog/pop-up.component';

@Component({
  selector: 'app-add-edit-cat',
  templateUrl: './add-edit-cat.component.html',
  styleUrls: ['./add-edit-cat.component.css']
})
export class AddEditCatComponent implements OnInit {
  firstFormGroup: FormGroup;
  category!: any;
  selected: string = '';
  categorys: any = [];
  constructor(private _categoryService: CategoryService,
    public dialog: MatDialog, private _productService: ProductService,
    private _location: Location, private _activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) {


    this.firstFormGroup = this.formBuilder.group({
      name: ['', Validators.required],
     

    });
  }

  ngOnInit(): void {
    let categoryID = this._activatedRoute.snapshot.paramMap.get('categoryID');
    if (categoryID != "") {
      this._categoryService.getCategory(categoryID).subscribe(data => {

        this.category = data;
        console.log(JSON.stringify(this.category))
        this.firstFormGroup.controls['name'].setValue(this.category['name']);
    
      })


    }
  }
  back() {
    this._location.back();
  }
  onSubmit() {
    if (this.firstFormGroup.invalid) {
      const dialogRef = this.dialog.open(PopUpDialog, {
        width: '250px',
        data: { question: "Error ", ok: false }
      });
      return;
    }

    if (this._activatedRoute.snapshot.paramMap.get('categoryID') != "") {
      const dialogRef = this.dialog.open(PopUpDialog, {
        width: '250px',
        data: { question: "Do you want to update this Category", ok: true }
      });

      dialogRef.afterClosed().subscribe(
        data => {
          if (data == true) {
            this.category = Object.assign({}, this.firstFormGroup.value);
            this.category['ID'] = '' + this._activatedRoute.snapshot.paramMap.get('categoryID');
            this._categoryService.UpdateCategory(this.category).subscribe(data => { this.back(); })

          }
        }
      );
    }
    else {
      const dialogRef = this.dialog.open(PopUpDialog, {
        width: '250px',
        data: { question: "Do you want to Add this Category", ok: true }
      });

      dialogRef.afterClosed().subscribe(
        data => {
          if (data == true) {
            this.category = Object.assign({}, this.firstFormGroup.value);
            console.log(this.category)
            this._categoryService.AddCategory(this.category).subscribe(data => { this.back(); })

          }
        }
      );
    }
  }
}
