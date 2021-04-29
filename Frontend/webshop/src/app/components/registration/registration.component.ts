import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';


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
  sub!: Subscription;

  constructor(private fb: FormBuilder, private router: Router, private http: HttpClient) {
  }

  ngOnInit() {
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      confirmEmail: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
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
    const userData = {
      'firstname': this.registerForm.value.firstName,
      'lastname': this.registerForm.value.lastName,
      'email': this.registerForm.value.email,
      'password': this.registerForm.value.password,
    }

    this.http.post("http://localhost:6600/api/customers/register", userData)
      .subscribe( response => {
          this.router.navigate(["/"]);
      }, err => {
        window.alert("This email has been already registered");
      })
  }
}
