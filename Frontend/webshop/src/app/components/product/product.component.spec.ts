import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from 'src/app/services/guards/auth-guard.service';

import { ProductComponent } from './product.component';

describe('ProductComponent', () => {
  let component: ProductComponent;
  let fixture: ComponentFixture<ProductComponent>;

  let jwtHelper: JwtHelperService;
  const testBedConfiguration = {
    imports: [
      RouterTestingModule.withRoutes([]),
      HttpClientTestingModule,
      JwtModule.forRoot({ // for JwtHelperService
        config: {
          tokenGetter: () => {
            return '';
          }
        }
      })
    ],
    providers: [
      AuthGuard,
      JwtHelperService
    ]
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        MatDialogModule,
        FormsModule,
        RouterTestingModule,
        HttpClientTestingModule,
        ReactiveFormsModule,
        MatSnackBarModule
      ],
      declarations: [ ProductComponent ],
      providers: [
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: MatDialogRef, useValue: {} },
        JwtHelperService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    TestBed.configureTestingModule(testBedConfiguration);
    jwtHelper = TestBed.get(JwtHelperService);
    fixture = TestBed.createComponent(ProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
