import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ICustomer } from '../components/shared/customer/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  customer: ICustomer = {
    firstName: '',
    lastName: '',
    email: '',
    password: ''
  };

  constructor(private jwtHelper: JwtHelperService, private http: HttpClient) { }

  getCustomerData() {
    const token = sessionStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      this.http.get<ICustomer>("http://localhost:6600/api/customers/" + this.customer.email).subscribe(response => {
        this.customer = response;
      }, err => {
        console.log(err)
      });
    }
  }

  getName() {
    return this.customer.firstName + ' ' + this.customer.lastName;
  }

  setEmail(email: string) {
    this.customer.email = email;
  }
}
