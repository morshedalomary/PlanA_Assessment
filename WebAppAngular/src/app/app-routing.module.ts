import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditCatComponent } from './category/add-edit-cat/add-edit-cat.component';
import { CategoryComponent } from './category/category.component';
import { HomeComponent } from './home/home.component';
import { AddEditProdComponent } from './product/add-edit-prod/add-edit-prod.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'product', component: ProductComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'addproduct/:productID', component: AddEditProdComponent  },
  { path: 'addcategory/:categoryID', component: AddEditCatComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
