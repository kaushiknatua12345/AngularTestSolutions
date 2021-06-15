import { inject, TestBed } from '@angular/core/testing';

import { CalculationService } from './calculation.service';

describe('CalculationsService tests', () => {
    let calculationsSvc: CalculationService;
   
    beforeEach(inject(
      [CalculationService],
      (calcService: CalculationService) => {
        calculationsSvc = calcService;
      }
    ));

  it("should calcuate Total Bill Based on Quantity*Price+13.5%GST Amount", () => {
    let result = calculationsSvc.BiilCalculation(5, 4500);
    expect(result).toEqual(25537.5);
  });
  });
