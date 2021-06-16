import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculationService {

  totalCost:number;
  gstAmount:number;
  billAmount:number;
  BiilCalculation(quantity:number,perProductCost:number)
  {
    this.totalCost=quantity*perProductCost;
    this.gstAmount=(this.totalCost*13.5)/100;
    this.billAmount=this.totalCost+this.gstAmount;
    return this.billAmount;
  }
}
