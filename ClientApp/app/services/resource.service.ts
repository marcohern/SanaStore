import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { Product } from '../models/product';
import { RequestService } from './request.service';
import { DmResult } from '../models/dm-result';

@Injectable()
export class ResourceService {
    constructor(private req: RequestService) { }

    public all(uri: string):Observable<any> {
        return this.req.get(uri);
    }

    public single(uri: string, id:number): Observable<any> {
        return this.req.get(uri + '/' + id);
    }

    public create(uri: string, data: any): Observable<DmResult> {
        return this.req.post(uri, data).map((r: Response) => <DmResult>r.json());
    }

    public update(uri: string, id: number, data: any): Observable<DmResult> {
        return this.req.put(uri, data).map((r: Response) => <DmResult>r.json());
    }

    public delete(uri: string, id: number): Observable<DmResult> {
        return this.req.delete(uri + '/' + id).map((r: Response) => <DmResult>r.json());
    }
}