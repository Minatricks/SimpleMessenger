import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../../models/message';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  private connectionUrl = 'http://localhost:5000/messages';
  private hubConnection: HubConnection;
  message = ' ';
  currentMessage = new Message();

  ngOnInit() {
    this.configureHubConnection();
    this.startConnection();
    this.subscribeOnEvent('notify', this.alertMessage);
  }

  public sendMessage() {
    this.currentMessage.TextMessage = this.message;
    this.currentMessage.IdSender = 1;
    this.currentMessage.DateTime = new Date(2012, 12, 10);
    this.hubConnection
      .invoke('notify', this.currentMessage)
      .catch(err => alert(err));
  }

  private configureHubConnection() {
    this.hubConnection = new HubConnectionBuilder().withUrl(this.connectionUrl).build();
  }

  private startConnection() {
    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(error => {
        alert('Error while establishing connection');
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
