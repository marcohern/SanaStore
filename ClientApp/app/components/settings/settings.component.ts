import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../../services/settings.service';
import { Settings } from '../../models/settings';

@Component({
    selector: 'products',
    templateUrl: './settings.component.html'
})
export class SettingsComponent implements OnInit {

    mode: number = 0;

    constructor(private ss:SettingsService) { }

    ngOnInit() {
        this.ss.get().subscribe(settings => {
            console.log(settings);
            this.mode = settings.sourceType;
        }, error => {

        });
    }

    apply() {
        console.log(this.mode);
        this.ss.apply(this.mode).subscribe(result => {
            console.log(result);
        }, error => {
        });
    }
}
