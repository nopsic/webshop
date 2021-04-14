import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';
import { IProduct } from '../product';

@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  pageTitle = 'Product Detail';
  errorMessage = '';
  product: IProduct | undefined;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private productService: ProductService) {
  }

  ngOnInit(): void {
    const param = this.route.snapshot.paramMap.get('code');
    if (param) {
      const code = param;
      this.getProduct(code);
    }
  }

  getProduct(code: string): void {
    this.productService.getProduct(code).subscribe({
      next: product => this.product = product,
      error: err => this.errorMessage = err
    });
  }

  onBack(): void {
    this.router.navigate(['/products']);
  }
}
