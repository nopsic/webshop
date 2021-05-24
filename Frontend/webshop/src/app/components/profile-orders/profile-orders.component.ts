import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { environment } from '../../../environments/environment';

export class Order {
  orderId: number = 0;
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  instrumentName: string = '';
  code: string = '';
  price: string = '';
  quantity: string = '';
  billingCity: string = '';
  billingState: string = '';
  billingPostalCode: string = '';
  billingAddress: string = '';
  date: string = '';
  orderNumber: string = '';
  status: string = '';
}

@Component({
  selector: 'app-profile-orders',
  templateUrl: './profile-orders.component.html',
  styleUrls: ['./profile-orders.component.css']
})
export class ProfileOrdersComponent implements OnInit {
  showProgress: boolean = false;
  orders: Order[] = [];
  sub!: Subscription;
  dataSource: MatTableDataSource<Order>;
  displayedColumns: string[] = ['orderNumber', 'status', 'instrumentName', 'code', 'price', 'quantity'];

  @ViewChild(MatSort) sort = new MatSort();

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.showProgress = true;
    this.sub = this.http.get<Order[]>(`${environment.apiURL}` + "/api/orders/" + sessionStorage.getItem("email"))
      .subscribe(response => {
        this.orders = response;
        this.dataSource = new MatTableDataSource(this.orders);
        this.dataSource.sort = this.sort;
        console.log(this.orders);
        this.showProgress = false;
      }, err => {
        let config = new MatSnackBarConfig();
        config.panelClass = ["custom-style"];
        this.snackBar.open("Something went wrong", "Close", config);
        this.showProgress = false;
      })
  }

}
