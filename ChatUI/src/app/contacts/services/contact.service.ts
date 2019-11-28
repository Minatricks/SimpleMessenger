import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { ContactViewModel } from '../models/contact-view-model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private readonly userControllerUrl = 'http://localhost:5000/contacts';
  private cacheContacts: Array<ContactViewModel>;
  constructor(private httpClient: HttpClient, private coockieService: CookieService) { }

  getMyContacts() {
    const myId = this.coockieService.getCookie(CoockieConstants.id);
    return this.httpClient.get(`${this.userControllerUrl}?userId=${myId}&skip=0&take=1000`);
  }

  addToCache(contact: ContactViewModel) {
    if (this.cacheContacts === null || this.cacheContacts === undefined) {
      this.cacheContacts = new Array<ContactViewModel>();
    }

    this.cacheContacts.push(contact);
  }

  getFromCache() {
    return this.cacheContacts;
  }

}
