import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  invalidLogin: boolean;
  hide: boolean = true;
  showProgress: boolean = false;

  constructor(private fb: FormBuilder, private router: Router, private http: HttpClient, private customerService: CustomerService) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.loginForm = this.fb.group({
      email: ["", [Validators.required, Validators.email]],
      password: ["", Validators.required]
    });
  }

  async login() {
    this.showProgress = true;
    const credentials = {
      'email': this.loginForm.value.email,
      'password': this.loginForm.value.password
    }

    this.http.post("http://localhost:6600/api/customers/login", credentials)
      .subscribe(response => {
        const token = (<any>response).token;
        sessionStorage.setItem("jwt", token);
        this.invalidLogin = false;
        sessionStorage.setItem("email", credentials.email);
        this.customerService.getCustomerData();
        this.router.navigate(["/"]);
        this.showProgress = false;
      }, err => {
        this.invalidLogin = true;
      })
  }
}
