import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';



export const routes: Routes = [

    { path: 'home', component: HomeComponent },
    { path: '', component: LoginComponent }


];

@NgModule({

    imports: [
        RouterModule.forRoot(routes),
        CommonModule
    ],
    exports: [RouterModule],
    declarations: []


})
export class AppRoutingModule {



}
