import { Component } from '@angular/core';
import {CalculationService} from './calculation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Bill Calculation';
  quantity:number=3;
  perProductCost:number=1000;
  totalBillAmount:number;

  constructor(private calculationService:CalculationService){
  this.totalBillAmount=this.calculationService.BiilCalculation(this.quantity,this.perProductCost);
  }


}
