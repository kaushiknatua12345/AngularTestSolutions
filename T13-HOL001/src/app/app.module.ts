import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{Routes,RouterModule} from '@angular/router';
import { AppComponent } from './app.component';
import { DepartmentInfoComponent } from './department-info/department-info.component';

const routes:Routes=[
{path:'DepartmentInfo/:DepartmentName',component:DepartmentInfoComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    DepartmentInfoComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
