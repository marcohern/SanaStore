import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { Product } from '../models/product';

@Injectable()
export class RequestService {
    constructor(private http: Http) { }

    private buildHeaders(): Headers {
        const headers: Headers = new Headers();
        headers.append('Accept', 'application/json');
        headers.append('Content-Type', 'application/json');
        return headers;
    }

    private handleRequest(data: any) {
        console.info("REQUEST",data);
    }

    private handleError(error:Response) {
        console.error("ERROR", error);
        return Observable.throw(error.json().error || 'Server error');
    }

    public get(url: string):Observable<any> {
        return this.http.get(url, { headers: this.buildHeaders() })
            .do(data => this.handleRequest(data))
            .catch(error => this.handleError(error));
    }

    public post(url: string, data:any): Observable<any> {
        return this.http.post(url, data, { headers: this.buildHeaders() })
            .do(data => this.handleRequest(data))
            .catch(error => this.handleError(error));
    }

    public put(url: string, body: any): Observable<any> {
        return this.http
            .put(url, body, { headers: this.buildHeaders() })
            .do(data => this.handleRequest(data))
            .catch(error => this.handleError(error));
    }

    public delete(url: string): Observable<any> {
        return this.http
            .delete(url, { headers: this.buildHeaders() })
            .do(data => this.handleRequest(data))
            .catch(error => this.handleError(error));
    }
}