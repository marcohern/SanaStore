import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ResourceService } from './resource.service';
import { DmResult } from '../models/dm-result';
import { Settings } from '../models/settings';

@Injectable()
export class SettingsService {
    private static uri: string = '/api/Settings';

    constructor(private res: ResourceService) { }

    public get(): Observable<Settings> {
        return this.res
            .all(SettingsService.uri)
            .map((r: Response) => <Settings>r.json());
    }

    public apply(sourceType: number): Observable<DmResult> {
        return this.res.create(SettingsService.uri, { sourceType: sourceType });
    }
}