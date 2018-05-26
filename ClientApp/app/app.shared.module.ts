import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductComponent } from './components/product/product.component';
import { SettingsComponent } from './components/settings/settings.component';
import { ResourceService } from './services/resource.service';
import { RequestService } from './services/request.service';
import { ProductService } from './services/products.service';
import { CategoriesService } from './services/categories.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ProductsComponent,
        ProductComponent,
        SettingsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'products', component: ProductsComponent },
            { path: 'product', component: ProductComponent },
            { path: 'product/:id', component: ProductComponent },
            { path: 'settings', component: SettingsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        RequestService,
        ResourceService,
        ProductService,
        CategoriesService
    ]
})
export class AppModuleShared {
}
