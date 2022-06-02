import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { ProductService } from '../../services/product.service';
import { IProduct } from '../../model/IProduct';
import { MatDialog } from '@angular/material/dialog';
import { PopUpDialog } from '../../pop-up-dialog/pop-up.component';
import { ICategory } from '../../model/ICategory';
import { CategoryService } from '../../services/category.service';
import { compileSchema } from 'ajv/dist/compile';
interface Dietary {
  value: string;
  viewValue: string;
}
@Component({
  selector: 'app-add-edit-prod',
  templateUrl: './add-edit-prod.component.html',
  styleUrls: ['./add-edit-prod.component.css']
})

export class AddEditProdComponent implements OnInit {
  dietarys: Dietary[] = [
    { value: 'vegan', viewValue: 'vegan' },
    { value: 'lactose-free', viewValue: 'lactose-free' },
    { value: 'Naturally plant-based', viewValue: 'Naturally plant-based' },
    { value: 'dairy and frozen desserts', viewValue: 'dairy and frozen desserts' },
    
  ];
  firstFormGroup: FormGroup;
  product!: any;
  fileToUpload: any;
  dietarySelected : string=''
  fileUpload: string = '' ;
  selectedFile: any = null;
  byteArrayImage :any =[]
  src = ''
  imageSrc : string = ''
  selected: string = '';
  categorys: any =[];
  constructor(private _categoryService: CategoryService , public dialog: MatDialog , private _productService: ProductService , private _location: Location, private _activatedRoute: ActivatedRoute , private formBuilder: FormBuilder) {
    this.firstFormGroup = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', null],
      price: [0, Validators.required],
      dietary_flags: ['', Validators.required],
      number_of_Views: [0, null],
      categoryID: ['', Validators.required],

    }); }


  handleFileInput(e: any) {
    this.fileToUpload = e?.target?.files[0];
    if (e.target.files.length === 0) {
      return;
    }
    let fileReader = new FileReader();
    fileReader.onload = (e) => {
      this.imageSrc = fileReader.result + "";
    


    }
    fileReader.readAsDataURL(e.target.files[0]);

  }

  ngOnInit(): void {
    this._categoryService.getAllCategoryList().subscribe(data => {
      this.categorys = data;

      this.selected = this.categorys[0]['id']

    })
    let productID  = this._activatedRoute.snapshot.paramMap.get('productID');
    if (productID != "") {
      this._productService.getProduct(productID).subscribe(data => {

        this.product = data;
        console.log(JSON.stringify(this.product))
        this.firstFormGroup.controls['title'].setValue(this.product['title']);
        this.firstFormGroup.controls['description'].setValue(this.product['description']);
        this.firstFormGroup.controls['price'].setValue(this.product['price']);
        this.firstFormGroup.controls['dietary_flags'].setValue(this.product['dietary_flags']);
        this.firstFormGroup.controls['number_of_Views'].setValue(this.product['number_of_Views']);
        this.firstFormGroup.controls['categoryID'].setValue(this.product['categoryID']);
        this.selected = this.product['categoryID']
        this.dietarySelected = this.product['dietary_flags'];
        this.imageSrc = 'data:image/jpeg;base64,' + this.product['image']
        this.fileToUpload = this.product['image'];

      })


    }

  }


 


  onSubmit() {


    if (this.firstFormGroup.invalid) {
      const dialogRef = this.dialog.open(PopUpDialog, {
        width: '250px',
        data: { question: "Error ", ok: false }
      });
      return;
    }

    if (this._activatedRoute.snapshot.paramMap.get('productID') != "") {
      const dialogRef = this.dialog.open(PopUpDialog, {
        width: '250px',
        data: { question: "Do you want to update this Product", ok: true }
      });

      dialogRef.afterClosed().subscribe(
        data => {
          if (data == true) {
            this.product = Object.assign({}, this.firstFormGroup.value);
           
            this.product['ID'] = '' + this._activatedRoute.snapshot.paramMap.get('productID');
            var formData: FormData = new FormData();
            formData.append('ID', this.product['ID']);

            formData.append('Title', this.firstFormGroup.controls['title'].value);
            formData.append('Description', this.firstFormGroup.controls['description'].value);
            formData.append('Price', this.firstFormGroup.controls['price'].value);

            formData.append('Dietary_flags', this.firstFormGroup.controls['dietary_flags'].value);

            formData.append('Number_of_Views', this.firstFormGroup.controls['number_of_Views'].value);
            formData.append('CategoryId', this.firstFormGroup.controls['categoryID'].value);
            formData.append('Image', this.fileToUpload);
            this._productService.UpdateProduct(formData).subscribe(data => { this.back(); })
          
          }
        }
      );
    }
    else {
      const dialogRef = this.dialog.open(PopUpDialog, {
        width: '250px',
        data: { question: "Do you want to Add this Product", ok: true }
      });

      dialogRef.afterClosed().subscribe(
        data => {
          if (data == true) {
            this.product = Object.assign({}, this.firstFormGroup.value);
            var formData: FormData = new FormData();
            formData.append('Title', this.firstFormGroup.controls['title'].value);
            formData.append('Description', this.firstFormGroup.controls['description'].value);
            formData.append('Price', this.firstFormGroup.controls['price'].value);

            formData.append('Dietary_flags', this.firstFormGroup.controls['dietary_flags'].value);

            formData.append('Number_of_Views', this.firstFormGroup.controls['number_of_Views'].value);
            formData.append('CategoryId', this.firstFormGroup.controls['categoryID'].value);

            formData.append('Image', this.fileToUpload);


            this._productService.AddProduct(formData).subscribe(data => { this.back(); })
           
          }
        }
      );
    }
  }
  back() {
    this._location.back();
  }

}
