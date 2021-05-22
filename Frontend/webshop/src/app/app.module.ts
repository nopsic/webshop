import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav'; 
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { AppRoutingModule } from './app-routing.module';
import { MatCardModule } from '@angular/material/card';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSliderModule } from '@angular/material/slider'; 
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatRadioModule } from '@angular/material/radio';
import { MatTableFilterModule } from 'mat-table-filter';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDialogModule } from '@angular/material/dialog'; 
import { MatCheckboxModule } from '@angular/material/checkbox';
import { JwtModule } from "@auth0/angular-jwt";
import { MatBadgeModule } from '@angular/material/badge';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { AppComponent } from './app.component';
import { StarComponent } from './shared/star.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component';
import { ProductDetailComponent } from './components/product/product-detail/product-detail.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { DeleteDialogComponent } from './components/dialog/delete-dialog/delete-dialog.component';
import { AboutUsComponent } from './components/about-us/about-us.component';

export function tonkenGetter() {
  return sessionStorage.getItem("jwt");
}

const MaterialComponents = [
  MatSidenavModule,
  MatMenuModule,
  MatButtonModule,
  MatToolbarModule,
  MatIconModule,
  MatCardModule,
  MatProgressSpinnerModule,
  MatInputModule,
  MatTabsModule,
  MatTableModule,
  MatSortModule,
  MatPaginatorModule,
  MatSelectModule,
  MatFormFieldModule,
  MatSliderModule,
  MatProgressBarModule,
  MatRadioModule,
  MatTableFilterModule,
  MatStepperModule,
  MatDialogModule,
  MatCheckboxModule,
  MatBadgeModule,
  MatGridListModule,
  MatDividerModule,
  MatListModule,
  MatSnackBarModule
]

@NgModule({
  declarations: [
    AppComponent,
    StarComponent,
    FooterComponent,
    NavComponent,
    ShoppingCartComponent,
    HomeComponent,
    ProductComponent,
    ProductDetailComponent,
    RegistrationComponent,
    DialogComponent,
    LoginComponent,
    ProfileComponent,
    DeleteDialogComponent,
    AboutUsComponent
  ],
  entryComponents: [DialogComponent],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MaterialComponents,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CdkStepperModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tonkenGetter,
        allowedDomains: ["localhost:6600"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
