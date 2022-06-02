import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';



@Injectable()

export class Config {


  constructor(private _http: HttpClient) { }
  appConfig: any;


  public static apiUrl: string = 'https://localhost:44348/api';



}









