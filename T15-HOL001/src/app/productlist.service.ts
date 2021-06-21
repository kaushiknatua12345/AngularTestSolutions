import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductlistService {

  products=['AC','Fridge','TV'];

  addProduct(product: string) {
    if (!(this.products.filter(u => u === product).length > 0)) {
      this.products.push(product);
    }
  }
  getProducts() {
    return this.products;
  }
}
