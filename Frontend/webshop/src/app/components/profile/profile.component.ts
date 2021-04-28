import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  customers: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get("http://localhost:6600/api/customers").subscribe(response => {
      this.customers = response;
    }, err => {
      console.log(err)
    });
  }

}
