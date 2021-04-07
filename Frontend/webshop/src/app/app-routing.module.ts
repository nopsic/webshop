import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { ProductListComponent } from "./products/product-list.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'aboutus', component: ProductListComponent },
  { path: 'signup', component: ProductListComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  //{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {

}