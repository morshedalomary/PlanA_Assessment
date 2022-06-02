import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatFileUploadModule } from 'angular-material-fileupload';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { CategoryComponent } from './category/category.component';
import { CategoryService } from './services/category.service';
import { CategoryEndPointService } from './servicesEndPoint/category-endPoint.service';
import { ProductService } from './services/product.service';
import { ProductEndPointService } from './servicesEndPoint/product-endPoint.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddEditCatComponent } from './category/add-edit-cat/add-edit-cat.component';
import { AddEditProdComponent } from './product/add-edit-prod/add-edit-prod.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule, MatPaginatorIntl } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CdkTableModule } from '@angular/cdk/table';
import { MatSortModule } from '@angular/material/sort';
import { PopUpDialog } from './pop-up-dialog/pop-up.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    CategoryComponent,
    AddEditCatComponent,
    PopUpDialog,
    AddEditProdComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatCardModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatIconModule,
    CdkTableModule,
    MatProgressSpinnerModule,
    MatTableModule,
    AppRoutingModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatSelectModule,
    MatFileUploadModule,
    MatListModule
 
  ],
  exports: [CommonModule, MatToolbarModule, MatInputModule, MatTableModule],

  providers: [CategoryService , CategoryEndPointService , ProductService , ProductEndPointService],
  bootstrap: [AppComponent],
  entryComponents: [PopUpDialog]

})
export class AppModule { }
