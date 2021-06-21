import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {RouterModule,Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { RouterTestingModule } from '@angular/router/testing';

const routes:Routes=[
  {path:'Home',component:HomeComponent},
  {path:'AboutUs',component:AboutusComponent}
]

@NgModule({
  declarations: [
    AppComponent,HomeComponent,AboutusComponent
  ],  
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    RouterTestingModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
