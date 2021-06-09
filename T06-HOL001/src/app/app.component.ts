import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Calculator Application';
  
  public num1:any;
  public num2;
  result;
  output;
  check:boolean=false;
  //InvalidDataMessage="Invalid Input";

  constructor()
  {   
   
  }

Addition()
{
  if(this.num1>0 && this.num2>0)
  {
  this.result=this.num1+this.num2;
  this.output= "The Addition Result is: "+this.result;
  this.check=true;
  return this.output;
  }
  else
  {
    this.num2=0;
    this.num2=0;
    this.check=false;
    this.output="Invalid Input";
    return this.output;
  }
}

Substraction()
{
  if(this.num1>0 && this.num2>0)
  {
  this.result=this.num1-this.num2;
  this.output= "The Substraction Result is: "+this.result;
  this.check=true;
  return this.output;
  }
  else
  {
    this.num2=0;
    this.num2=0;
    this.check=false;
    this.output="Invalid Input";
    return this.output;
  }
}

Multiplication()
{
  if(this.num1>0 && this.num2>0)
  {
  this.result=this.num1*this.num2;
  this.output= "The Multiplication Result is: "+this.result;
  this.check=true;
  return this.output;
  }
  else
  {
    this.num2=0;
    this.num2=0;
    this.check=false;
    this.output="Invalid Input";
    return this.output;
  }

}

Division()
{
  if(this.num1>0 && this.num2>0)
  {
  this.result=this.num1/this.num2;
  this.output= "The Division Result is: "+this.result;
  this.check=true;
  return this.output;
}
else
{
  this.num2=0;
  this.num2=0;
  this.check=false;
  this.output="Invalid Input";
  return this.output;
}
}

}
