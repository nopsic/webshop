// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-shopping-cart',
//   templateUrl: './shopping-cart.component.html',
//   styleUrls: ['./shopping-cart.component.css']
// })
// export class ShoppingCartComponent implements OnInit {
//   carts;
//   cartDetails;
//   constructor(private http: HttpService) {}
//   _getCart(): void {
//     this.http.getCartItems().subscribe((data: any) => {
//       this.carts = data.data;
//       // this.cartDetails = data.data;
//       console.log(this.carts);
//     });
//   }
//   _increamentQTY(id, quantity): void {
//     const payload = {
//       productId: id,
//       quantity,
//     };
//     this.http.increaseQty(payload).subscribe(() => {
//       this._getCart();
//       alert('Product Added');
//     });
//   }
//   _emptyCart(): void {
//     this.http.emptyCart().subscribe(() => {
//       this._getCart();
//       alert('Cart Emptied');
//     });
//   }
//   ngOnInit(): void {
//     this._getCart();
//   }
// }