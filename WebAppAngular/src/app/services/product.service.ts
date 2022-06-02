import { Injectable } from '@angular/core';
import { ProductEndPointService } from '../servicesEndPoint/product-endPoint.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private _productEndPointService: ProductEndPointService) { }
  getAllProductList() {
    return this._productEndPointService.getAllProductList();
  }

  getSearchProductList(text: any) {
    return this._productEndPointService.getSearchProductList(text);

  }
  AddProduct(product: any) {
    return this._productEndPointService.AddProduct(product);

  }
  DeleteProduct(idProduct: any) {

    return this._productEndPointService.DeleteProduct(idProduct);

  }
  UpdateProduct(product: any) {

    return this._productEndPointService.UpdateProduct(product);

  }
  getProduct(idProduct : any ) {
    return this._productEndPointService.getProduct(idProduct);

  }

}
