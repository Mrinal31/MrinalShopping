import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthenticationService } from '../shared/services/user.service';
import { Router } from '@angular/router';
import { Environment } from '../core/environments';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    constructor(private service: AuthenticationService, private router: Router) { }
    env = Environment.isLoggedIn;

    ngOnInit() {
    }


    login(username: string, password: string) {

        this.service.authenticateUser(username, password).subscribe(
            (result) => {
                this.service.setCurrentUser(result.user);
                this.service.saveJWTToken(result.token);
                this.router.navigateByUrl('/home');
                this.env = true; 
            }


        );

    }


}
