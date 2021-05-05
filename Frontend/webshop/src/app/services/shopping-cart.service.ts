import { Injectable } from '@angular/core';
import { IProduct } from '../components/product/product';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  private cartItems: IProduct[] = [];

  constructor() { }

  addItem(product: IProduct): void {
    let found: boolean = false;

    this.cartItems.forEach((element, index) => {
      if (element.code === product.code) {
        this.cartItems[index].quantity += product.quantity;
        found = true;
        return;
      }
    });
    
    if (!found) {
      this.cartItems.push(product);
    }
  }

  removeItem(product: IProduct): void {
    this.cartItems.forEach((element, index) => {
      if (element === product) {
        delete this.cartItems[index];
        return;
      }
    });
  }

  getCartItems(): IProduct[] {
    return this.cartItems;
  }
}
