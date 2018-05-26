import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Product } from '../models/product';
import { ResourceService } from './resource.service';

@Injectable()
export class ProductService {
    constructor(private res: ResourceService) { }

    public all() : Observable<Product[]> {
        return this.res
            .all('/api/Products')
            .map((r: Response) => <Product[]>r.json());
    }
}