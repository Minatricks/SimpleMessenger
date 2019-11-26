import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { LoginModel } from '../../models/login-model';
import { UserModel } from '../../models/user-model';
import { HttpErrorResponse } from '@angular/common/http';
import { UserRightsConstant } from 'src/app/shared/models/user-rights-constant';
import { CookieService } from 'src/app/shared/sevices/cookie.service';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {

  constructor(
    private router: Router,
    private userService: UserService,
    private cookieService: CookieService) {

  }

  ngOnInit() {
  }

  logIn(loginModel: LoginModel) {
    this.userService.logIn(loginModel).subscribe(
      (data: UserModel) => { this.getUser(data); },
      (error: HttpErrorResponse) => { this.handlerError(error); });
  }

  private getUser(user: UserModel) {
    this.cookieService.setCookie(UserRightsConstant.token, user.token, { 'max-age': 3600 });
    this.cookieService.setCookie(UserRightsConstant.role, user.role, { 'max-age': 3600 });
    this.router.navigate(['/message']);
  }

  private handlerError(error: HttpErrorResponse) {
    if (error.error === undefined) {
      alert(error.statusText);
    } else {
      alert(`${error.error.error} with login ${error.error.parameters[0]}`);
    }
  }

}
