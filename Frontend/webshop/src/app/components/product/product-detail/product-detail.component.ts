import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ShoppingCartService } from '../../../services/shopping-cart.service';
import { ProductService } from '../../../services/product.service';
import { IProduct } from '../product';

@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  pageTitle: string = 'Instrument Detail';
  errorMessage: string = '';
  product: IProduct | undefined;

  showMatProgress: boolean = false;
  quantityInput: number = 1;
  quantityControl: FormControl;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private productService: ProductService,
              private shoppingCartService: ShoppingCartService) {
  }

  ngOnInit(): void {
    const param = this.route.snapshot.paramMap.get('code');
    if (param) {
      const code = param;
      this.getProduct(code);
    }
  }

  getProduct(code: string): void {
    this.showMatProgress = true;
    this.productService.getProduct(code).subscribe({
      next: product => {
        this.product = product;
        this.quantityControl = new FormControl("", [Validators.max(this.getQuantity()), Validators.min(1), Validators.required]);
        this.quantityControl.setValue(this.quantityInput);
      },
      error: err => this.errorMessage = err
    });
    this.showMatProgress = false;
  }

  onBack(): void {
    this.router.navigate(['/products']);
  }

  minusOne() {
    if (this.quantityInput > 1) {
      this.quantityInput--;
      this.quantityControl.setValue(this.quantityInput);
    }
  }

  plusOne() {
    if (this.quantityInput < this.product.quantity) {
      this.quantityInput++;
      this.quantityControl.setValue(this.quantityInput);
    }
  }

  getQuantity(): number{
    return this.product.quantity;
  }

  addToCart() {
    if (!this.quantityControl.invalid) {
      let myProduct = {
        instrumentId: 0,
        name: '',
        code: '',
        price: 0,
        description: '',
        rating: 0,
        image: null,
        quantity: 0,
        type: ''
      }

      myProduct.instrumentId = this.product.instrumentId;
      myProduct.name = this.product.name;
      myProduct.code = this.product.code;
      myProduct.price = this.product.price;

      myProduct.quantity = Number(this.quantityInput);

      this.shoppingCartService.addItem(myProduct);
    }
  }

  onDataChange(value: number) {
    this.quantityInput = value;
  }
}
