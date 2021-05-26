import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from 'src/app/services/guards/auth-guard.service';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

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
        RouterTestingModule,
        HttpClientTestingModule,
        ReactiveFormsModule,
        MatSnackBarModule
      ],
      declarations: [ LoginComponent ],
      providers: [
        JwtHelperService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    TestBed.configureTestingModule(testBedConfiguration);
    jwtHelper = TestBed.get(JwtHelperService);
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
