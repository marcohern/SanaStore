import { ProductCategory } from "./product-category";

export class Category {
    id?: number;
    name: string = '';
    productCategories: ProductCategory[] = [];
}