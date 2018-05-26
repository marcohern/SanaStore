import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/products.service';
import { CategoriesService } from '../../services/categories.service';
import { Category } from '../../models/category';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {

    product?: Product;
    categories: Category[] = [];
    productFormGroup: FormGroup;

    constructor(private ps: ProductService,private cs:CategoriesService, private router: Router, private route: ActivatedRoute, private fb: FormBuilder) {
        this.productFormGroup = this.fb.group({
            name: this.fb.control(''),
            price: this.fb.control('')
        });
    }

    ngOnInit() {
        this.cs.all().subscribe(categories => {
            console.info("CATEGORIES", categories);
            this.categories = categories;

            var id = this.route.snapshot.params['id'];
            if (id) {
                this.ps.get(id).subscribe(product => {
                    console.info("PRODUCT", product);
                    this.product = product;
                    this.productFormGroup.setValue({
                        name: product.name,
                        price: product.price
                    });

                }, error => {
                    console.error("PRODUCT ERROR", error);
                });
            }
        }, error => {
            console.error("CATEGORIES ERROR", error);
        });
    }

    toggle(category: Category) {
        category.selected = !category.selected;
        console.log("toggle", category);
    }

    submit() {
        console.info("values", this.productFormGroup.value);
        console.info("categories", this.categories);
        if (this.productFormGroup.valid) {
            var activeCats: Category[] = [];
            for(let category of this.categories) {
                if (category.selected) activeCats.push(category);
            }
            if (!this.product) {
                this.product = new Product();
            }
            this.product.name = this.productFormGroup.value.name;
            this.product.price = this.productFormGroup.value.price;

            this.ps.create(this.product, activeCats).subscribe(result => {
                this.router.navigate(['/products']);
            }, error => {
                console.error("CREATE PRODUCT ERROR", error);
            });
        }
    }
}
