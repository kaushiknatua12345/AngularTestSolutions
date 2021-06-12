import { Component, OnInit } from '@angular/core';

import { IEmployee } from './IEmployee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements IEmployee{

  title="Employee Information";
  
  id: number;
  name: string;
  salary: number;
  permanent: boolean;

  constructor(){}  

    DisplayId()
    {
      this.id=1001;
      return this.id;
    }

    DisplayName()
    {
      this.name="Sam";
      return this.name;
    }

    DisplaySalary()
    {
      this.salary=5000;
      return this.salary;
    }

    DisplayPermanentOrNot()
    {
      this.permanent=true;
      return this.permanent;
    }   

}
