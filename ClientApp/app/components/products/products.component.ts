import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/products.service';

@Component({
    selector: 'products',
    templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {

    products: Product[] = [];

    constructor(private ps: ProductService) {

    }

    ngOnInit() {
        this.ps.all().subscribe(products => {
            console.log("PRODUCTS", products);
            this.products = products;
        }, error => {
            console.error("PRODUCTS ERROR", error);
        });
    }
}
