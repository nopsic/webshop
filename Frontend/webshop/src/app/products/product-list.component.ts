import { Component, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { Subscription } from "rxjs";
import { IProduct } from "../components/product/product";
import { ProgressSpinnerComponent } from "../components/shared/progress-spinner/progress-spinner.component";
import { ProductService } from "../services/product.service";

@Component({
    selector: 'app-products',
    templateUrl: './product-list.component.html',
    styleUrls: [
      './product-list.component.css'
    ]
})

export class ProductListComponent implements OnInit, OnDestroy{
  @ViewChild(ProgressSpinnerComponent, { static: true }) Progress: ProgressSpinnerComponent;

  pageTitle: string = 'List of musical instruments';
  imageWidth: number = 50;
  imageMargin: number = 2;
  showImage: boolean = false;
  errorMessage: string = '';
  sub!: Subscription;
  spinner: ProgressSpinnerComponent = new ProgressSpinnerComponent();
  
  
  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredProducts = this.performFilter(value);
  }


  filteredProducts: IProduct[] = [];
  products: IProduct[] = [];

  constructor(private productService: ProductService) {}

  performFilter(filterBy: string) : IProduct[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((product: IProduct) =>
      product.name.toLocaleLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.sub = this.productService.getProducts().subscribe({
      next: products => {
        this.products = products;
        this.filteredProducts = this.products;
      },
      error: err => this.errorMessage
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}