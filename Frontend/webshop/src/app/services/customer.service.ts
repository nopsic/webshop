import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';
import { ICustomer } from '../components/shared/customer/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private jwtHelper: JwtHelperService, private http: HttpClient) { }

  getCustomerData() {
    const token = sessionStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      this.http.get<ICustomer>(`${environment.apiURL}` + "/api/customers/" + sessionStorage.getItem("email")).subscribe(response => {
        sessionStorage.setItem("firstName", response.firstName);
        sessionStorage.setItem("lastName", response.lastName);
      }, err => {
        console.log(err)
      });
    }
  }

  getFirstName() {
    return sessionStorage.getItem("firstName");
  }

  getLastName() {
    return sessionStorage.getItem("lastName");
  }

  getEmail() {
    return sessionStorage.getItem("email");
  }
}
