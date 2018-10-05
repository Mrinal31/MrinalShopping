import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Environment } from './/core/environments';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'app';
    env = Environment.isLoggedIn;
    constructor(private router: Router) {


    }

    logout() {

        localStorage.clear();
        this.router.navigateByUrl('');
    }
}
