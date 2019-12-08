import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { UserModel } from 'src/app/user/models/user-model';
import { ContactModel } from '../models/contact-model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private readonly userControllerUrl = 'http://localhost:5000/contacts';
  constructor(private httpClient: HttpClient, private coockieService: CookieService) { }

  getMyContacts() {
    const myId = this.coockieService.getCookie(CoockieConstants.id);
    return this.httpClient.get(`${this.userControllerUrl}?userId=${myId}&skip=0&take=1000`);
  }
}
