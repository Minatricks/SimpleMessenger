import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { LoginModel } from '../models/login-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly userControllerUrl = 'http://localhost:5000/user';
  private readonly securityHeader = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')

  constructor(private httpClient: HttpClient) {
  }

  logIn(loginModel: LoginModel) {
    const body = this.generateSecurityBody(loginModel);
    return this.httpClient
      .post(`${this.userControllerUrl}/auth`, body.toString(), { headers: this.securityHeader });
  }

  register(loginModel: LoginModel) {
    const body = this.generateSecurityBody(loginModel);
    return this.httpClient
      .post(`${this.userControllerUrl}/register`, body.toString(), { headers: this.securityHeader });
  }

  logOut() {

  }

  private generateSecurityBody(loginModel: LoginModel) {
    return new HttpParams()
      .set('username', loginModel.username)
      .set('password', loginModel.password);
  }

}
