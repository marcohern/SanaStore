import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/products.service';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {

    product?: Product;
    productFormGroup: FormGroup;

    constructor(private ps: ProductService, private router: Router, private route: ActivatedRoute, private fb: FormBuilder) {
        this.productFormGroup = this.fb.group({
            name: this.fb.control('')
        });
    }

    ngOnInit() {
        var id = this.route.snapshot.params['id'];
        if (id) {
            this.ps.get(id).subscribe(product => {
                console.info("PRODUCT", product);
            }, error => {
                console.error("PRODUCT ERROR", error);
            });
        }
    }
}
