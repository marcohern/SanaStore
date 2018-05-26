import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Product } from '../models/product';
import { ResourceService } from './resource.service';
import { DmResult } from '../models/dm-result';
import { Category } from '../models/category';

@Injectable()
export class ProductService {
    private static uri: string = '/api/Products';

    constructor(private res: ResourceService) { }

    public all() : Observable<Product[]> {
        return this.res
            .all(ProductService.uri)
            .map((r: Response) => <Product[]>r.json());
    }

    public get(id: number): Observable<Product> {
        return this.res
            .single(ProductService.uri, id)
            .map((r:Response) => <Product>r.json());
    }

    public create(product: Product, categories: Category[]): Observable<DmResult> {
        return this.res.create(ProductService.uri, { product: product, categories: categories });
    }

    public update(id: number, product: Product, categories: Category[]): Observable<DmResult> {
        return this.res.update(ProductService.uri, id, { product: product, categories: categories });
    }

    public save(product: Product, categories: Category[]): Observable<DmResult> {
        if (product.id) {
            return this.update(product.id, product, categories);
        } else {
            return this.create(product, categories);
        }
    }

    public delete(id: number): Observable<DmResult> {
        return this.res.delete(ProductService.uri, id);
    }
}