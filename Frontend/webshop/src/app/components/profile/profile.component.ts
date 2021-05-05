import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { ICustomer } from '../shared/customer/customer';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {
  customer: ICustomer;
  customerName: string = '';
  showProgress: boolean = false;

  constructor(private http: HttpClient, private router: Router, private customerService: CustomerService) { }

  ngOnInit() {
    this.customerName = this.customerService.getName();
  }

  logOut() {
    sessionStorage.removeItem("jwt");
    this.router.navigate(['/']);
  }
}
