import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';

import { AuthGuard } from './auth-guard.service';

describe('AuthGuardService', () => {
  let service: AuthGuard;

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
      providers: [
        JwtHelperService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    TestBed.configureTestingModule(testBedConfiguration);
    jwtHelper = TestBed.get(JwtHelperService);
    service = TestBed.inject(AuthGuard);
  });


  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
