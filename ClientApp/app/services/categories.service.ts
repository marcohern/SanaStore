import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Product } from '../models/product';
import { ResourceService } from './resource.service';
import { DmResult } from '../models/dm-result';
import { Category } from '../models/category';

@Injectable()
export class CategoriesService {
    private static uri: string = '/api/Categories';

    constructor(private res: ResourceService) { }

    public all(): Observable<Category[]> {
        return this.res
            .all(CategoriesService.uri)
            .map((r: Response) => <Category[]>r.json());
    }
}