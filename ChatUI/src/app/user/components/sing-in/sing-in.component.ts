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
    localStorage.setItem(UserRightsConstant.token, user.token);
    localStorage.setItem(UserRightsConstant.role, user.role);
  }

  private handlerError(error: HttpErrorResponse) {
    alert(error.statusText);
  }


}
