import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

export interface ICustomer {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {
  customer: ICustomer;
  customerName: string = "";
  showProgress: boolean = false;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    // this.http.get("http://localhost:6600/api/customers").subscribe(response => {
    //   this.customers = response;
    // }, err => {
    //   console.log(err)
    // });

    this.showProgress = true;
    this.http.get<ICustomer>("http://localhost:6600/api/customers/" + localStorage.getItem("email")).subscribe(response => {
      this.customer = response;
      this.customerName = this.customer.firstName + ' ' + this.customer.lastName;
    }, err => {
      console.log(err)
    });
    this.showProgress = false;
  }

  logOut() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("email");
    this.router.navigate(['/']);
  }
}
