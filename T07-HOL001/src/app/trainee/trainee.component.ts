import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-trainee',
  templateUrl: './trainee.component.html',
  styleUrls: ['./trainee.component.css']
})
export class TraineeComponent implements OnInit {

  @ViewChild('registerForm',{static:true}) registerForm:NgForm;
  message:string;
  traineename:string;
  emailid:string;

  constructor() { }

  ngOnInit() {
    this.message='';
  }

  public submitForm()
  {
    if(this.registerForm.valid)
    {
      this.message='Registration Form Is Valid';
      this.traineename='';
      this.emailid='';
      this.registerForm.reset();
    }
  }

}
