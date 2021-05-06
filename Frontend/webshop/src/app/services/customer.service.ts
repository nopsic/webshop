import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ICustomer } from '../components/shared/customer/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private jwtHelper: JwtHelperService, private http: HttpClient) { }

  getCustomerData() {
    const token = sessionStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      this.http.get<ICustomer>("http://localhost:6600/api/customers/" + sessionStorage.getItem("email")).subscribe(response => {
        sessionStorage.setItem("firstName", response.firstName);
        sessionStorage.setItem("lastName", response.lastName);
      }, err => {
        console.log(err)
      });
    }
  }

  getName() {
    return sessionStorage.getItem("firstName") + ' ' + sessionStorage.getItem("lastName");
  }
}
