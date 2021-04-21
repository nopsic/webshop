import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";
import { ProductDetailComponent } from "./components/product/product-detail/product-detail.component";
import { ProductComponent } from "./components/product/product.component";
import { RegistrationComponent } from "./components/registration/registration.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products/code/:code', component: ProductDetailComponent },
  { path: 'products', component: ProductComponent },
  { path: 'aboutus', component: ProductComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  //{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {

}