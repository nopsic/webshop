import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { CustomerService } from '../../services/customer.service';
import { DeleteDialogComponent } from '../dialog/delete-dialog/delete-dialog.component';
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

  constructor(private router: Router, private customerService: CustomerService,
              public dialog: MatDialog, private http: HttpClient,
              private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.customerName = this.customerService.getFirstName() + ' ' + this.customerService.getLastName();
  }

  logOut() {
    sessionStorage.removeItem("jwt");
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("firstName");
    sessionStorage.removeItem("lastName");
    this.router.navigate(['/']);
    let config = new MatSnackBarConfig();
    config.panelClass = ["success-style"];
    config.duration = 3000;
    this.snackBar.open("You have logged out successfully!", "Close", config);
  }

  dialogResponse(): void {
    let dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: {}
  });

    dialogRef.afterClosed().subscribe(result => {
      if (result === "yes") {
        this.showProgress = true;

        this.http.delete(`${environment.apiURL}` + "/api/customers/" + sessionStorage.getItem("email"))
          .subscribe(response => {
            sessionStorage.removeItem("jwt");
            sessionStorage.removeItem("email");
            sessionStorage.removeItem("firstName");
            sessionStorage.removeItem("lastName");
            let config = new MatSnackBarConfig();
            config.panelClass = ["success-style"];
            config.duration = 3000;
            this.snackBar.open("You have deleted your account successfully!", "Close", config);
            this.router.navigate(['/']);
            this.showProgress = false;
          }, err => {
            console.log(err);
        })
      }
    });
  }

  navigateToOrders(): void {
    this.router.navigate(['/profile-orders']);
  }
}
