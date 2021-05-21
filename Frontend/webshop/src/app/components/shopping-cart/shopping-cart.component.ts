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
import { environment } from 'src/environments/environment';

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
  displayedColumns: string[] = ['name', 'code', 'minus', 'quantity', 'plus', 'price', 'delete'];

  showProgress: boolean = false;

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

    this.showProgress = true;
    this.products = this.cartService.getCartItems();
    this.dataSource = new MatTableDataSource(this.products);
    this.showProgress = false;
  }

  orderCheck(): void {
    this.showProgress = true;
    this.http.post(`${environment.apiURL}` + "/api/instruments/quantity", this.products)
      .subscribe( response => {
        this.placeOrder();
      }, err => {
        window.alert(err.error.text);
        this.showProgress = false;
      })
  }

  placeOrder(): void {
    this.products.forEach(element => {
      element.price = element.price * element.quantity;
    });

    let city = this.thirdFormGroup.get("billingCity").value;
    let state = this.thirdFormGroup.get("billingState").value;
    let postalCode = this.thirdFormGroup.get("billingPostalCode").value;
    let address = this.thirdFormGroup.get("billingAddress").value;

    let json1 = JSON.parse(JSON.stringify(city + ";" + state + ";" + postalCode + ";" + address));
    let json2 = JSON.parse((JSON.stringify(this.products)));

    let jsonConcat = json2.concat(json1);

    this.http.post(`${environment.apiURL}` + "/api/orders/" + sessionStorage.getItem("email") + "/" + this.products.length, jsonConcat)
      .subscribe( response => {
        window.alert("Your order was registered! Thank you!");
        this.showProgress = false;
        this.reset();
        this.router.navigate(["/"]);
      }, err => {
        console.log(err);
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
    this.cartService.removeAlItem();

    this.products = [];

    this.dataSource = new MatTableDataSource(this.products);
  }

  removeFunction(array: IProduct[], value: IProduct) {
    return array.filter(function(element) {
      return element != value;
    });
  }

  deleteItem(item : IProduct) {
    this.cartService.removeItem(item);

    this.products = this.removeFunction(this.products, item);

    this.dataSource = new MatTableDataSource(this.products);
  }
}