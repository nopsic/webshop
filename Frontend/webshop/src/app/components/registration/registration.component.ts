import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


function notTheSameControlValues(controlName1: string, controlName2: string, errorName: string){
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

  constructor(private fb: FormBuilder) {
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
      validator: [notTheSameControlValues('password', 'confirmPassword', 'notTheSame'), notTheSameControlValues('email', 'confirmEmail', 'different')]
    });
  }

  clear() {
    this.registerForm.patchValue({
      firstName: "",
      lastName: "",
      city: "",
      state: "",
      postalCode: "",
      address: "",
    });
  }

  onSubmit() {
    console.warn(this.registerForm.value);
  }
}
