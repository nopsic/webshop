import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { ProductListComponent } from './products/product-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StarComponent } from './shared/star.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
//import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { MatSidenavModule } from '@angular/material/sidenav'; 
import { NavComponent } from './components/shared/nav/nav.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { MatCardModule } from '@angular/material/card';
import { HttpClientModule } from '@angular/common/http';
import { ProductComponent } from './components/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    StarComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    //ShoppingCartComponent,
    HomeComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatMenuModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    AppRoutingModule,
    MatCardModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
