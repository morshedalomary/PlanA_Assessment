import { Byte } from "@angular/compiler/src/util";
import { ICategory } from "./ICategory";

export interface IProduct {
  ID: string;
  Title: string;
  Description: string;
  Price: number;
  Image: Uint8Array[];
  Number_of_Views : number 
  Dietary_flags: string;
	CategoryId  : string
}
















