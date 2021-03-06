import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AboutUsComponent } from "./components/about-us/about-us.component";
import { HomeComponent } from "./components/home/home.component";
import { ProfileOrdersComponent } from "./components/profile-orders/profile-orders.component";
import { LoginComponent } from "./components/login/login.component";
import { ProductDetailComponent } from "./components/product/product-detail/product-detail.component";
import { ProductComponent } from "./components/product/product.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { RegistrationComponent } from "./components/registration/registration.component";
import { ShoppingCartComponent } from "./components/shopping-cart/shopping-cart.component";
import { AuthGuard } from "./services/guards/auth-guard.service";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products/code/:code', component: ProductDetailComponent },
  { path: 'products', component: ProductComponent },
  { path: 'aboutus', component: AboutUsComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'shoppingcart', component: ShoppingCartComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'profile-orders', component: ProfileOrdersComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {

}