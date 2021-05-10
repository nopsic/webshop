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

  constructor(private router: Router, private customerService: CustomerService) { }

  ngOnInit() {
    this.customerName = this.customerService.getFirstName() + ' ' + this.customerService.getLastName();
  }

  logOut() {
    sessionStorage.removeItem("jwt");
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("firstName");
    sessionStorage.removeItem("lastName");
    this.router.navigate(['/']);
  }
}
