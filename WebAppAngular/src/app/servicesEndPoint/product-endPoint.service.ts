import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Config } from '../config';
import { IProduct } from '../model/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductEndPointService {
  get getSearchProductListUrl() { return Config.apiUrl + this._getSearchProductListUrl; }

  get getAllProductListUrl() { return Config.apiUrl + this._getAllProductListUrl; }
  private readonly _getAllProductListUrl: string = '/Product/all';
  private readonly _getSearchProductListUrl: string = '/Product/search';

  
  get AddProductUrl() { return Config.apiUrl + this._AddProductUrl; }
  private readonly _AddProductUrl: string = '/Product';
  constructor(private _http: HttpClient) { }


  getSearchProductList(text : string): Observable<IProduct[]> {
    
    const endpointUrl = this.getSearchProductListUrl + "/" + text;
    return this._http.get<IProduct[]>(endpointUrl);

  }

  getAllProductList(): Observable<IProduct[]> {

    const endpointUrl =  this.getAllProductListUrl;
    return this._http.get<IProduct[]>(endpointUrl);

  }
  AddProduct(Product: any) {
    const endpointUrl = this.AddProductUrl +"/AddProduct/";

    return this._http.post(endpointUrl, Product, { headers: new HttpHeaders() })

  }
  DeleteProduct(idProduct: any) {

    const endpointUrl =  this.AddProductUrl + "/" + idProduct;
    return this._http.delete(endpointUrl);

  }
  UpdateProduct(Product: any) {

    const endpointUrl = this.AddProductUrl;

    return this._http.put(endpointUrl, Product)

  }
  getProduct(idProduct: any): Observable<IProduct>{

    const endpointUrl = this.AddProductUrl + "/" + idProduct;
    return this._http.get<IProduct>(endpointUrl);

  }
}
