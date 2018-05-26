import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../../services/settings.service';
import { Settings } from '../../models/settings';

class Mode {
    id: number = 0;
    name: string = '';
}

@Component({
    selector: 'products',
    templateUrl: './settings.component.html'
})
export class SettingsComponent implements OnInit {

    mode?: Mode;
    modeval: number = 0;

    modes:Mode[] = [
        { id: 1, name: "Sql Server" },
        { id: 2, name: "In Memory" }
    ];

    constructor(private ss:SettingsService) { }

    ngOnInit() {
        this.ss.get().subscribe(settings => {
            console.log(settings);
            this.mode = this.modes.find(m => m.id == settings.sourceType) || { id: 0, name: "" };
            this.modeval = this.mode.id;
        }, error => {

        });
    }

    apply() {
        console.log(this.modeval);
        if (this.modeval) {
            this.ss.apply(this.modeval).subscribe(result => {
                this.mode = this.modes.find(m => m.id == this.modeval) || { id: 0, name: "" };
                console.log(result);
            }, error => {
            });
        }
    }
}
