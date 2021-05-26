import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from 'src/app/services/guards/auth-guard.service';
import { ShoppingCartComponent } from './shopping-cart.component';

describe('ShoppingCartComponent', () => {
  let component: ShoppingCartComponent;
  let fixture: ComponentFixture<ShoppingCartComponent>;

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
        BrowserAnimationsModule,
        MatSnackBarModule,
        HttpClientModule,
        BrowserAnimationsModule,
        CommonModule,
        ReactiveFormsModule,
      ],
      declarations: [ ShoppingCartComponent ],
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
    fixture = TestBed.createComponent(ShoppingCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
