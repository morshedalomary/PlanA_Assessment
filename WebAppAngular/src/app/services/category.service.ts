import { Injectable } from '@angular/core';
import { CategoryEndPointService } from '../servicesEndPoint/category-endPoint.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private _categoryEndPoint: CategoryEndPointService) { }

  getCategory(idCategory: any) {
    return this._categoryEndPoint.getCategory(idCategory);

  }
  getAllCategoryList() {
    return this._categoryEndPoint.getAllCategoryList();
  }

  
  AddCategory(category: any) {

    return this._categoryEndPoint.AddCategory(category);

  }
  DeleteCategory(idCategory: any) {

    return this._categoryEndPoint.DeleteCategory(idCategory);

  }
  UpdateCategory(category: any) {

    return this._categoryEndPoint.UpdateCategory(category);

  }


}
