import { inject, TestBed } from '@angular/core/testing';

import { ProductlistService } from './productlist.service';

describe('ProductlistService', () => {
  let productListSvc: ProductlistService;
   
    beforeEach(inject(
      [ProductlistService],
      (productListService: ProductlistService) => {
      productListSvc = productListService;
      }
    ));

  it("should add product and display the product added", () => {
    productListSvc.addProduct('Ear Bud');
    expect(productListSvc.getProducts().pop()).toEqual('Ear Bud');
  });
});
