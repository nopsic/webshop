import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Subscription } from 'rxjs';
import { IProduct } from './product';
import { ProductService } from "../../services/product.service";
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableFilter } from 'mat-table-filter';

export class Product {
  instrumentId: string = '';
  name: string = '';
  code: string = '';
  price: string = '';
  description: string = '';
  rating: string = '';
  pictureName: string = '';
  type: string = '';
}

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
  pageTitle: string = "List of musical instruments";
  value = 'Search here';
  minPrice: number = null;
  maxPrice: number = null;
  minRating: number = null;
  maxRating: number = null;
  errorMessage: string = '';
  sub!: Subscription;
  displayedColumns: string[] = ['pictureName', 'name', 'code', 'rating', 'price'];

  searchProduct: IProduct = {
    instrumentId: 0,
    name: '',
    code: '',
    price: 0,
    description: '',
    rating: 0,
    image: null,
    type: '',
    quantity: 0
  };

  activeTab = 0;


  @ViewChildren(MatSort) sort = new QueryList<MatSort>();
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();

  filterEntity: Product = {
    instrumentId: '',
    name: '',
    code: '',
    price: '',
    description: '',
    rating: '',
    pictureName: '',
    type: ''
  };
  filterType: MatTableFilter;

  dataSource: MatTableDataSource<IProduct>;
  products: IProduct[] = [];

  showMatProgress: boolean = false;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.showMatProgress = true;
    this.sub = this.productService.getProducts().subscribe({
      next: products => {
        this.products = products;
        this.dataSource = new MatTableDataSource(this.products);
        this.dataSource.paginator = this.paginator.toArray()[0];
        this.dataSource.sort = this.sort.toArray()[0];
        this.filterEntity = new Product();
        this.filterType = MatTableFilter.ANYWHERE;
        this.showMatProgress = false;
      },
      error: err => this.errorMessage
    });
  }

  setNullMin() {
    this.minPrice = null;
    this.applyPriceFilter();
  }

  setNullMax() {
    this.maxPrice = null;
    this.applyPriceFilter();
  }

  setMinRatingNull() {
    this.minRating = null;
    this.applyPriceFilter();
  }

  setMaxRatingNull() {
    this.maxRating = null;
    this.applyPriceFilter();
  }

  applyRatingFilter() {
    if (this.minRating === null && this.maxRating === null) {

    }
    else if((this.minRating === null ||  this.minRating.toString().length === 0) && this.maxRating !== null && this.maxRating.toString().length !== 0) {
      this.dataSource.data = this.dataSource.data.filter(e => e.rating <= this.maxRating);
    }
    else if (this.minRating !== null && (this.maxRating === null || this.maxRating.toString().length === 0) && this.minRating.toString().length !== 0) {
      this.dataSource.data = this.dataSource.data.filter(e => e.rating >= this.minRating);
    }
    else if(this.minRating !== null && this.maxRating !== null && this.minRating.toString().length !== 0 && this.maxRating.toString().length !== 0) {
      this.dataSource.data = this.dataSource.data.filter(e => (e.rating < Number(this.maxRating) + 0.1) && (e.rating > this.minRating - 0.1));
    }
  }

  applyPriceFilter() {
    this.dataSource = new MatTableDataSource(this.products);
    this.dataSource.paginator = this.paginator.toArray()[this.activeTab];
    this.dataSource.sort = this.sort.toArray()[this.activeTab];

    if (this.minPrice === null && this.maxPrice === null) {

    }
    else if((this.minPrice === null ||  this.minPrice.toString().length === 0) && this.maxPrice !== null && this.maxPrice.toString().length !== 0) {
      this.dataSource.data = this.dataSource.data.filter(e => e.price < (Number(this.maxPrice) + 1));
    }
    else if (this.minPrice !== null && (this.maxPrice === null || this.maxPrice.toString().length === 0) && this.minPrice.toString().length !== 0) {
      this.dataSource.data = this.dataSource.data.filter(e => e.price > this.minPrice - 1);
    }
    else if(this.minPrice !== null && this.maxPrice !== null && this.minPrice.toString().length !== 0 && this.maxPrice.toString().length !== 0) {
      this.dataSource.data = this.dataSource.data.filter(e => e.price < (Number(this.maxPrice) + 1) && e.price > this.minPrice - 1);
    }

    this.applyRatingFilter();
  }

  showProductTable(): boolean {
    if (this.products && this.products.length > 0) {
      return true;
    }

    return false;
  }

  tabClick(tab) {
    console.log(tab.index);
    this.getProductsBySelectedTab(tab.index);
  }

  getProductsBySelectedTab(tabIndex: number) {
    this.activeTab = tabIndex;
    if(tabIndex == 0) {
      this.showMatProgress = true;
      this.dataSource = new MatTableDataSource([]);
      this.sub = this.productService.getProducts().subscribe({
        next: products => {
          this.products = products;
          this.dataSource = new MatTableDataSource(this.products);
          this.dataSource.paginator = this.paginator.toArray()[0];
          this.dataSource.sort = this.sort.toArray()[0];
          this.filterEntity = new Product();
          this.filterType = MatTableFilter.ANYWHERE;
          this.showMatProgress = false;
          this.applyPriceFilter();
        },
        error: err => {
          this.errorMessage = err;
          this.showMatProgress = false;
        }
      });
    }
    else if(tabIndex == 1) {
      this.showMatProgress = true;
      this.dataSource = new MatTableDataSource([]);
      this.sub = this.productService.getProductsByType("brass").subscribe({
        next: products => {
          this.products = products;
          this.dataSource = new MatTableDataSource(this.products);
          this.dataSource.paginator = this.paginator.toArray()[1];
          this.dataSource.sort = this.sort.toArray()[1];
          this.filterEntity = new Product();
          this.filterType = MatTableFilter.ANYWHERE;
          this.showMatProgress = false;
          this.applyPriceFilter();
        },
        error: err => {
          this.errorMessage = err;
          this.showMatProgress = false;
        }
      });
    }
    else if(tabIndex == 2) {
      this.showMatProgress = true;
      this.dataSource = new MatTableDataSource([]);
      this.sub = this.productService.getProductsByType("woodwind").subscribe({
        next: products => {
          this.products = products;
          this.dataSource = new MatTableDataSource(this.products);
          this.dataSource.paginator = this.paginator.toArray()[2];
          this.dataSource.sort = this.sort.toArray()[2];
          this.filterEntity = new Product();
          this.filterType = MatTableFilter.ANYWHERE;
          this.showMatProgress = false;
          this.applyPriceFilter();
        },
        error: err => {
          this.errorMessage = err;
          this.showMatProgress = false;
        }
      });
    }
    else if(tabIndex == 3) {
      this.showMatProgress = true;
      this.dataSource = new MatTableDataSource([]);
      this.sub = this.productService.getProductsByType("percussion").subscribe({
        next: products => {
          this.products = products;
          this.dataSource = new MatTableDataSource(this.products);
          this.dataSource.paginator = this.paginator.toArray()[3];
          this.dataSource.sort = this.sort.toArray()[3];
          this.filterEntity = new Product();
          this.filterType = MatTableFilter.ANYWHERE;
          this.showMatProgress = false;
          this.applyPriceFilter();
        },
        error: err => {
          this.errorMessage = err;
          this.showMatProgress = false;
        }
      });
    }
    else if(tabIndex == 4) {
      this.showMatProgress = true;
      this.dataSource = new MatTableDataSource([]);
      this.sub = this.productService.getProductsByType("string").subscribe({
        next: products => {
          this.products = products;
          this.dataSource = new MatTableDataSource(this.products);
          this.dataSource.paginator = this.paginator.toArray()[4];
          this.dataSource.sort = this.sort.toArray()[4];
          this.filterEntity = new Product();
          this.filterType = MatTableFilter.ANYWHERE;
          this.showMatProgress = false;
          this.applyPriceFilter();
        },
        error: err => {
          this.errorMessage = err;
          this.showMatProgress = false;
        }
      });
    }
  }
}
