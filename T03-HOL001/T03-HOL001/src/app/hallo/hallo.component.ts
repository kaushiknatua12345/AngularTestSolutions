import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hallo',
  templateUrl: './hallo.component.html',
  styleUrls: ['./hallo.component.css']
})
export class HalloComponent {
  
  a=10;
  b=20;
  result=0;
  constructor() { 
    
  }

  Addition()
  {
    this.result=this.a+this.b;
    return this.result;
  }

  

}
