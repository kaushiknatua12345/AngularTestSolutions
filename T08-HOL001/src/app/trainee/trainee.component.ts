import { Component, OnInit } from '@angular/core';
import{FormGroup,FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-trainee',
  templateUrl: './trainee.component.html',
  styleUrls: ['./trainee.component.css']
})
export class TraineeComponent implements OnInit {

  title="Trainee Registration Form";
  constructor() { }
  
  studentForm;
  message:string;

  ngOnInit() {
    this.studentForm=new FormGroup(
      {
        studentName:new FormControl('',[
          Validators.required,          
        ]),
        emailid:new FormControl('',[
          Validators.required,Validators.email
        ])       
      });
  }

  public SubmitForm()
  {
    if(this.studentForm.valid)
    {
      this.message="Form Submitted Successfully";
    }
  }

}
