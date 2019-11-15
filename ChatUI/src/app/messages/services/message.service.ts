import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private connectionUrl = 'http://localhost:5000/messages';
  private hubConnection: HubConnection;
  message = ' ';
  currentMessage = new Message();

  onGetMessage(func) {
    this.configureHubConnection();
    this.startConnection();
    this.subscribeOnEvent('notify', this.alertMessage);
  }

  private configureHubConnection() {
    this.hubConnection = new HubConnectionBuilder().withUrl(this.connectionUrl).build();
  }

  private startConnection() {
    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(error => {
        //alert('Error while establishing connection');
        console.log(error);
      });
  }

  private subscribeOnEvent(eventName: string, func) {
    this.hubConnection.on(eventName, func);
  }

  private alertMessage(message: Message) {
    alert(`Sender: ${message.IdSender}, DateTime: ${message.DateTime}, Text: ${message.TextMessage}`);
  }
}
