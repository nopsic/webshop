import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  signInTitleString: string = "Sign in";
  instrumentQuantity: number = null;

  constructor(public dialog: MatDialog,
              private route: ActivatedRoute,
              private router: Router,
              private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(DialogComponent, {data: {title: this.signInTitleString}});

    dialogRef.afterClosed().subscribe(result => {
      if (result === "register") {
        this.router.navigate(['/register']);
      }
      else if (result === "signIn") {
        this.router.navigate(['/login']);
      }
    });
  }

  isUserAuthenticated() {
    const token: string = sessionStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  logOut() {
    sessionStorage.removeItem("jwt");
  }

  navigateToProfile() {
    this.router.navigate(['/profile']);
  }
}
