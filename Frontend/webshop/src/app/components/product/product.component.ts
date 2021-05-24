import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Subscription } from 'rxjs';
import { IProduct } from './product';
import { ProductService } from "../../services/product.service";
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
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

  constructor(private productService: ProductService,
              private router: Router) {}

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

  applyFilter(filterValue: string): void {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  logData(row): void {
    console.log(row);
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
        },
        error: err => {
          this.errorMessage = err;
          this.showMatProgress = false;
        }
      });
    }
  }
}
