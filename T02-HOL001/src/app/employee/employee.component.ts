import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  title="employee information"
  name="sam";
  salary=90000;
  joiningDate=new Date("2021/05/20");

  constructor() { }

  ngOnInit() {
  }

}
