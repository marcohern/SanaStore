import { ProductCategory } from "./product-category";

export class Category {
    id?: number;
    name: string = '';
    selected: boolean = false;
    productCategories: ProductCategory[] = [];
}