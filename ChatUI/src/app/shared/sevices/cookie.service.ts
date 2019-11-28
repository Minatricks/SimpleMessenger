import { Injectable } from '@angular/core';

@Injectable()
export class CookieService {

  constructor() { }

  getCookie(name): string {
    const matches = document.cookie.match(new RegExp(
      '(?:^|; )' + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + '=([^;]*)'
    ));
    return decodeURIComponent(matches[1]);
  }

  setCookie(name: string, value: string, options): void {
    options = { path: '/' };

    let updatedCookie = encodeURIComponent(name) + '=' + encodeURIComponent(value);

    for (const optionKey in options) {
      updatedCookie += '; ' + optionKey;
      const optionValue = options[optionKey];
      if (optionValue !== true) {
        updatedCookie += '=' + optionValue;
      }
    }

    document.cookie = updatedCookie;
  }

  deleteCookie(name: string): void {
    this.setCookie(name, '', { 'max-age': -1 });
  }

}
