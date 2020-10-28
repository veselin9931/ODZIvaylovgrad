import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { BehaviorSubject, Observable, throwError, empty } from 'rxjs';
import { UserRegister } from './user-register';
import { UserLogin } from './user-login';

@Injectable({
  providedIn: 'root'
})
export class DataService {

    public static readonly URLS: any = {
      LOGIN: 'api/account/login',
      REGISTER: 'api/account'
    };

  constructor(private httpClient: HttpClient) { }

//   private isAuthorizedSubject = new BehaviorSubject<boolean>(this.isAuthorized());

//   public isAuthorized$ = this.isAuthorizedSubject.asObservable();

public register(userRegister: UserRegister) {
  return this.httpClient.post(DataService.URLS.REGISTER, userRegister).pipe(
      map(() => {
          const userLogin = new UserLogin();
          userLogin.email = userRegister.email;
          userLogin.password = userRegister.password;

          return this.login();
      }),
      catchError(err => throwError(err)));
}

  public login(){
      // const payload = new HttpParams()
      //     .set('email', userLogin.email)
      //     .set('password', userLogin.password)
      //     .toString();

      // const headers = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');

      // return this.httpClient.post(DataService.URLS.LOGIN, payload, { headers: headers }).pipe(
      //     map((data: any) => {
      //         this.identityService.setToken(data['access_token'], data['expires_in']);
      //         this.identityService.setRoles(data['roles']);
      //         this.identityService.setEmail(userLogin.email);

      //         this.isAuthorizedSubject.next(true);

      //         this.routerService.redirectToHome();

      //         return empty();
      //     }),
      //     catchError(err => throwError(err)));
  }

//   public logout() {
//       this.identityService.removeIdentity();

//       this.isAuthorizedSubject.next(false);

//       this.routerService.redirectToHome();
//   }

//   public isAuthorized(): boolean {
//       return this.identityService.getToken() !== null;
//   }
}
