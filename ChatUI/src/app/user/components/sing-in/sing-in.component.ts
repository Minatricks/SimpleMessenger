import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { LoginModel } from '../../models/login-model';
import { UserModel } from '../../models/user-model';
import { HttpErrorResponse } from '@angular/common/http';
import { UserRightsConstant } from 'src/app/shared/models/user-rights-constant';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {

  constructor(private router: Router, private userService: UserService) {

  }
  ngOnInit() {
  }

  logIn(loginModel: LoginModel) {
    this.userService.logIn(loginModel).subscribe(
      (data: UserModel) => { this.getUser(data) },
      (error: HttpErrorResponse) => { this.handlerError(error) });
  }

  private getUser(user: UserModel) {
    this.setCookie(UserRightsConstant.token, user.token, { 'max-age': 3600 });
    this.setCookie(UserRightsConstant.role, user.role, { 'max-age': 3600 });
    alert(this.getCookie(UserRightsConstant.role) + "-" + this.getCookie(UserRightsConstant.token));
  }

  private handlerError(error: HttpErrorResponse) {
    alert(error.statusText);
  }

  getCookie(name) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return  decodeURIComponent(matches[1]);
  }

  setCookie(name: string, value: string, options): void {
    options = { path: '/' };

    let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

    for (let optionKey in options) {
      updatedCookie += "; " + optionKey;
      let optionValue = options[optionKey];
      if (optionValue !== true) {
        updatedCookie += "=" + optionValue;
      }
    }

    document.cookie = updatedCookie;
  }

  deleteCookie(name: string): void {
    this.setCookie(name, "", { 'max-age': -1 });
  }

}
