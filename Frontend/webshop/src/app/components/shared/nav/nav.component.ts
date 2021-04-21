import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  signInTitleString: string = "Sign in";

  constructor(public dialog: MatDialog,
              private route: ActivatedRoute,
              private router: Router) { }

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

  changeSignInTitleString(): void {
    if (this.signInTitleString === "Sign in") {
      this.signInTitleString = "Profile"
    }
    else if (this.signInTitleString === "Profile") {
      this.signInTitleString = "Sign in"
    }
  }
}
