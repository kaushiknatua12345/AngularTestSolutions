import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  title="employee details";
  name="sam";
  landlineNumber="0442567100";

  constructor() { }

  ngOnInit() {
  }

}
