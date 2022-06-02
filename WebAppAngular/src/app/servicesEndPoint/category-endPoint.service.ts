import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Config } from '../config';
import { ICategory } from '../model/ICategory';

@Injectable()
export class CategoryEndPointService {
  get getAllCategoryListUrl() { return Config.apiUrl + this._getAllCategoryListUrl; }
  private readonly _getAllCategoryListUrl: string = '/Category/all';
  get AddCategoryUrl() { return Config.apiUrl + this._AddCategoryUrl; }
  private readonly _AddCategoryUrl: string = '/Category';
  constructor(private _http: HttpClient) { }



  getAllCategoryList(): Observable<ICategory[]>{

    const endpointUrl =this.getAllCategoryListUrl;
    return this._http.get<ICategory[]>(endpointUrl);

  }
  AddCategory(category : any ){

    const endpointUrl = this.AddCategoryUrl + "/AddCategory/";

    console.log("AddCategory")
    console.log(endpointUrl)

    console.log(JSON.stringify(category))

    return this._http.post(endpointUrl, category);

  }
  DeleteCategory(idCategory: any) {

    const endpointUrl =  this.AddCategoryUrl +"/" +idCategory;
    return this._http.delete(endpointUrl);

  }
  UpdateCategory(category: any) {

    const endpointUrl = this.AddCategoryUrl;
    console.log("UpdateCategory")
    console.log(endpointUrl)

    console.log(JSON.stringify(category))
    return this._http.put(endpointUrl, category);

  }
  getCategory(idCategory: any): Observable<ICategory> {

    const endpointUrl = this.AddCategoryUrl + "/" + idCategory;
    return this._http.get<ICategory>(endpointUrl);

  }
}
