import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../models/message';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private connectionUrlForHub = 'http://localhost:5000/messages';
  private connectionUrlForController = 'http://localhost:5000/message';
  private hubConnection: HubConnection;

  constructor(private http: HttpClient) {

    this.configureHubConnection();
    this.startConnection();
  }

  onGetMessage(func): void {
    this.subscribeOnEvent('notify', func);
  }

  sendMessage(message: Message) {
    return this.http.post(this.connectionUrlForController, message);
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
