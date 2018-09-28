import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../../Models/Product';
import { Observable } from 'rxjs';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';


@Injectable()
export class ProductService {

    constructor(private http: HttpClient) {


    }
    productList: Product[];
    getProductList(): Observable<Product[]> {

        return this.http.get<Product[]>('api/product/getProductList')
             

    }
}
