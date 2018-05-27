import { Product } from "./product";
import { Category } from "./category";

export class ProductCategory {
    productId: number = 0;
    categoryId: number = 0;
    product?: Product;
    category?: Category;

}