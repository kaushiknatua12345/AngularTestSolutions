import { Component } from '@angular/core';
import{ProductlistService} from './productlist.service';
import{FormsModule} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Product App';
  newProduct='';
  constructor(private productListService:ProductlistService) { }  

  addProduct() {
    this.productListService.addProduct(this.newProduct);
  }

  getProducts() {
    return this.productListService.getProducts();
  }
}
