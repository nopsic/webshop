import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: {showError: true}
  }]
})
export class ShoppingCartComponent implements OnInit {
  registerForm = this.fb.group({
    firstName: ['', [Validators.required, Validators.minLength(2)]],
    lastName: ['', [Validators.required, Validators.minLength(2)]],
    deliveryCity: [''],
    deliveryState: [''],
    deliveryPostalCode: [''],
    deliveryAddress: ['', Validators.maxLength(140)],
    billingAddress: ['', Validators.maxLength(140)],
    sameAddress: [''],
  });

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  cartItemFormGroup: FormGroup;

  clientName: string = "";
  clientEmail: string = "";

  sameAddressIsChecked: boolean = false;

  childData: string;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.firstFormGroup = this.fb.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this.fb.group({
      secondCtrl: ['', Validators.required]
    });
    this.cartItemFormGroup = this.fb.group({
      firstCtrl: ['', Validators.required]
    });
  }

  getDeliveryAddress(): string {
    return this.registerForm.get('deliveryAddress').value.toString();
  }

  sameAddress() {
    if (!this.sameAddressIsChecked) {
      let address: string = this.getDeliveryAddress();

      this.registerForm.patchValue({
        billingAddress: address
      });

      this.sameAddressIsChecked = true;
    }
    else {
      this.sameAddressIsChecked = false;
    }
  }
  
}