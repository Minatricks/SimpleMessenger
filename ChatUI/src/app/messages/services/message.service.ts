import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../models/message';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';

@Injectable()
export class MessageService {
  private connectionUrlForHub = 'http://localhost:5000/messages';
  private connectionUrlForController = 'http://localhost:5000/message';
 private cacheMessages: Array<Message>;
  private hubConnection: HubConnection;

  constructor(private http: HttpClient, private coockieService: CookieService) {

    this.configureHubConnection();
    this.startConnection();
  }

  onGetMessage(func): void {
    this.subscribeOnEvent('notify', func);
  }

  sendMessage(message: Message) {
    return this.http.post(this.connectionUrlForController, message);
  }

  getMessages() {
    const recipientId = this.coockieService.getCookie(CoockieConstants.id);
    const senderId = this.coockieService.getCookie(CoockieConstants.currentContactId);
    return this.http.get(`${this.connectionUrlForController}/?recipientId=${recipientId}
    &senderId=${senderId}`);
  }

  addToCache(message: Message) {
    this.cacheMessages.push(message);
  }

  getFromCache() {
    return this.cacheMessages;
  }



  private configureHubConnection() {
    this.hubConnection = new HubConnectionBuilder().withUrl(this.connectionUrlForHub).build();
  }

  private startConnection() {
    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(error => {
        console.log(error);
      });
  }

  private subscribeOnEvent(eventName: string, func) {
    this.hubConnection.on(eventName, func);
  }

}
