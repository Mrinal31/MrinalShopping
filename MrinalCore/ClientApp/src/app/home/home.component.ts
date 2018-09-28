import { Component, OnInit } from '@angular/core';
import { Product } from '../Models/Product';
import { ProductService } from '../shared/services/product.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    constructor(private productservice: ProductService) { }
    productList: Product[];

    ngOnInit() {

        this.productservice.getProductList().subscribe(
            (result) => {

                this.productList = result;
                console.log(this.productList);

            }
        );

    }

}
