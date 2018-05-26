import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/products.service';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {

    product?:Product;

    constructor(private ps: ProductService, private router:Router, private route:ActivatedRoute) {
    }

    ngOnInit() {
        var id = this.route.snapshot.params['id'];
        this.ps.get(id).subscribe(product => {
            console.info("PRODUCT", product);
        }, error => {
            console.error("PRODUCT ERROR", error);
        });
    }
}
