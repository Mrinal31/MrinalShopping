import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Rx';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../Models/User';

@Injectable()
export class AuthenticationService {

    constructor(private http: HttpClient) { }

    authenticateUser(username: string, password: string): Observable<any> {

        return this.http.post<any>('api/login/auth', { username: username, password: password });
        //.map(user => {

        //    if (user) {

        //        localStorage.setItem('currentUser', JSON.stringify(user));
        //    }
        //    return user;

        //});

    }

    setCurrentUser(user: User) {


        if (localStorage.getItem["CurrentUser"] == null || typeof (localStorage.getItem) == "undefined") {

            localStorage.setItem("CurrentUser", JSON.stringify(user));

        }
    }

    saveJWTToken(token: string) {

        if (localStorage.getItem["Token"] == null || typeof (localStorage.getItem) == "undefined") {

            localStorage.setItem("Token", token);

        }

    }

}
