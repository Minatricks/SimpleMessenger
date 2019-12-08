import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../models/message';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { MessageUpdateService } from 'src/app/shared/sevices/message-update.service';

@Injectable()
export class MessageService {
  private connectionUrlForHub = 'http://localhost:5000/messages';
  private connectionUrlForController = 'http://localhost:5000/message';
  private hubConnection: HubConnection;

  constructor(private http: HttpClient,
    private coockieService: CookieService,
    private messageUpdateService: MessageUpdateService) {

    this.configureHubConnection();
    this.startConnection();
  }

  onGetMessage(): void {
    this.hubConnection.on('notify', () => {
      this.messageUpdateService.pushUpdateMessage(true);
    });
  }

  sendMessage(message: Message) {
    return this.http.post(this.connectionUrlForController, message);
  }

  getLastMessage(recipientId: Number, senderId: Number) {
    return this.http.get(`${this.connectionUrlForController}/last/?recipientId=${recipientId}
    &senderId=${senderId}`);
  }

  getMessages() {
    const recipientId = Number(this.coockieService.getCookie(CoockieConstants.id));
    const senderId = Number(this.coockieService.getCookie(CoockieConstants.currentContactId));
    return this.http.get(`${this.connectionUrlForController}/?recipientId=${recipientId}
    &senderId=${senderId}`);
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

}
