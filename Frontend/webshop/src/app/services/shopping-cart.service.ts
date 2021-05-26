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
        console.log(this.cartItems[index].quantity);
        console.log(product.quantity);
        this.cartItems[index].quantity += Number(product.quantity);
        let numberOfInstruments = Number(sessionStorage.getItem("instrumentQuantity"));
        numberOfInstruments += Number(product.quantity);
        sessionStorage.setItem("instrumentQuantity", numberOfInstruments.toString());
        found = true;
        return;
      }
    });

    if (!found) {
      this.cartItems.push(product);
      let numberOfInstruments = Number(sessionStorage.getItem("instrumentQuantity"));
        numberOfInstruments += Number(product.quantity);
        sessionStorage.setItem("instrumentQuantity", numberOfInstruments.toString());
    }
  }

  removeAlItem() : void {
    this.cartItems.forEach((element, index) => {
      this.cartItems = [];
      sessionStorage.setItem("instrumentQuantity", "0");
    });
  }

  removeFunction(array: IProduct[], value: IProduct) {
    return array.filter(function(element) {
      return element != value;
    });
  }

  removeItem(product: IProduct): void {
    this.cartItems.forEach((element, index) => {
      if (element === product) {
        let numberOfInstruments = Number(sessionStorage.getItem("instrumentQuantity"));
        numberOfInstruments -= Number(element.quantity);
        sessionStorage.setItem("instrumentQuantity", numberOfInstruments.toString());

        this.cartItems = this.removeFunction(this.cartItems, element);
      }
    });
  }

  getCartItems(): IProduct[] {
    return this.cartItems;
  }
}
