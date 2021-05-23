import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

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
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registerForm: FormGroup;
  emailInput: string = '';
  showProgress: boolean = false;

  constructor(private fb: FormBuilder, private router: Router, private http: HttpClient,
              private snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      confirmEmail: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required]],
    }, {
      validator: [notTheSameControlValues('password', 'confirmPassword'), notTheSameControlValues('email', 'confirmEmail')]
    });
  }

  clear() {
    this.registerForm.patchValue({
      firstName: "",
      lastName: "",
      email: "",
      confirmEmail: "",
      password: "",
      confirmPassword: ""
    });
  }

  onSubmit() {
    this.showProgress = true;
    const userData = {
      'firstname': this.registerForm.value.firstName,
      'lastname': this.registerForm.value.lastName,
      'email': this.registerForm.value.email,
      'password': this.registerForm.value.password,
    }

    this.http.post(`${environment.apiURL}` + "/api/customers/register", userData)
      .subscribe( response => {
        this.showProgress = false;
        this.router.navigate(["/"]);
        let config = new MatSnackBarConfig();
        config.panelClass = ["success-style"];
        config.duration = 3000;
        this.snackBar.open("Your registration was successful!", "Close", config);
      }, err => {
        this.showProgress = false;
        let config = new MatSnackBarConfig();
        config.panelClass = ["custom-style"];
        this.snackBar.open("This email has been already registered", "Close", config);
      })
  }
}
