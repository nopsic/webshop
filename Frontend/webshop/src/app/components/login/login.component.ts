import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hide: boolean = true;
  showProgress: boolean = false;

  constructor(private fb: FormBuilder, private router: Router, private http: HttpClient, 
              private customerService: CustomerService, private snackBar: MatSnackBar) { }

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

    this.http.post(`${environment.apiURL}` + "/api/customers/login", credentials)
      .subscribe(response => {
        const token = (<any>response).token;
        sessionStorage.setItem("jwt", token);
        sessionStorage.setItem("email", credentials.email);
        this.customerService.getCustomerData();
        this.router.navigate(["/"]);
        let config = new MatSnackBarConfig();
        config.panelClass = ["success-style"];
        config.duration = 3000;
        this.snackBar.open("Successfully logged in", "Close", config);
        this.showProgress = false;
      }, err => {
        let config = new MatSnackBarConfig();
        config.panelClass = ["custom-style"];
        this.snackBar.open("Wrong email or password", "Close", config);
        this.showProgress = false;
      })
  }
}
