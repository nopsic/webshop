import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { CustomerService } from '../../services/customer.service';
import { IProduct } from '../product/product';
import { HttpClient } from '@angular/common/http';
import { ViewChild } from '@angular/core';
import { TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

function notTheSameControlValues(controlName1: string, controlName2: string){
  return (formGroup: FormGroup) => {
      const control1 = formGroup.controls[controlName1];
      const control2 = formGroup.controls[controlName2];

      if (control2.errors && !control2.errors.different) {
          return;
      }
      if (control1.value !== control2.value) {
        control2.setErrors({ different: true });
      } else {
        control2.setErrors(null);
      }
  }
}

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: {showError: true}
  }]
})
export class ShoppingCartComponent implements OnInit {
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  fourthFormGroup: FormGroup;
  cartItemFormGroup: FormGroup;

  @ViewChild('successDialog') successDialog: TemplateRef<any>;

  dataSource: MatTableDataSource<IProduct>;
  products: IProduct[] = [];
  displayedColumns: string[] = ['name', 'code', 'minus', 'quantity', 'plus', 'price'];

  showMatProgress: boolean = false;

  constructor(private fb: FormBuilder, private customerService: CustomerService,
              private cartService: ShoppingCartService, private http: HttpClient,
              private router: Router) {}

  ngOnInit(): void {
    this.firstFormGroup = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]]
    });

    this.secondFormGroup = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      confirmEmail: ['']
    }, {
      validator: [notTheSameControlValues('email', 'confirmEmail')]
    });

    this.thirdFormGroup = this.fb.group({
      billingCity: ['', Validators.required],
      billingState: ['', Validators.required],
      billingPostalCode: ['', Validators.required],
      billingAddress: ['', [Validators.maxLength(140), Validators.required]],
    });

    this.cartItemFormGroup = this.fb.group({
      
    });

    if(this.customerService.getFirstName() !== "null" && this.customerService.getLastName() !== "null"
    && this.customerService.getEmail() !== "null") {
      this.firstFormGroup.get("firstName").patchValue(this.customerService.getFirstName());
      this.firstFormGroup.get("lastName").patchValue(this.customerService.getLastName());
      this.secondFormGroup.get("email").patchValue(this.customerService.getEmail());
      this.secondFormGroup.get("confirmEmail").patchValue(this.customerService.getEmail());
    }

    this.showMatProgress = true;
    this.products = this.cartService.getCartItems();
    console.log(this.products);
    this.dataSource = new MatTableDataSource(this.products);
    this.showMatProgress = false;
  }

  order(): void {
    this.http.post("http://localhost:6600/api/instruments/quantity", this.products)
      .subscribe( response => {
        window.alert("Your order was registered! Thank you!");
        this.router.navigate(["/"]);
      }, err => {
        window.alert(err.error.text);
      })
  }

  minusOne(element: IProduct): void {
    let index = this.products.indexOf(element);

    let product = this.products[index];

    product.quantity -= 1;

    let numberOfInstruments = Number(sessionStorage.getItem("instrumentQuantity"));
    numberOfInstruments -= 1;
    sessionStorage.setItem("instrumentQuantity", numberOfInstruments.toString());

    this.products[index] = product;

    this.dataSource = new MatTableDataSource(this.products);
  }

  plusOne(element: IProduct): void {
    let index = this.products.indexOf(element);

    let product = this.products[index];

    product.quantity += 1;

    let numberOfInstruments = Number(sessionStorage.getItem("instrumentQuantity"));
    numberOfInstruments += 1;
    sessionStorage.setItem("instrumentQuantity", numberOfInstruments.toString());

    this.products[index] = product;

    this.dataSource = new MatTableDataSource(this.products);
  }

  reset() {
    this.products = [];
    this.dataSource = new MatTableDataSource(this.products);
  }
}