import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-department-info',
  templateUrl: './department-info.component.html',
  styleUrls: ['./department-info.component.css']
})
export class DepartmentInfoComponent implements OnInit {

  public deptName:string="";
  constructor(private activeRoute:ActivatedRoute) { }

  ngOnInit() {
    this.deptName = this.activeRoute.snapshot.params.DepartmentName;
  }

}
