import { ProductCategory } from "./product-category";

export class Product {
    id?:number;
    name:string = '';
    price: number = 0;
    productCategories: ProductCategory[] = [];
}