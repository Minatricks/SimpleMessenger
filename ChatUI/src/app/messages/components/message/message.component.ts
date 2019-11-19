import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../../models/message';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  constructor(private messageService: MessageService) {

  }

  ngOnInit(): void {
    this.messageService.onGetMessage(this.alertMessage);
  }
  sendMessage(message: string) {
    let tempMessage = new Message();
    tempMessage.textMessage = message;
    tempMessage.idSender = 1;
    tempMessage.idRecipient = 2;
    this.messageService.sendMessage(tempMessage).subscribe(
      (date: any) => {
        alert(date);
      }
    )
  }
  alertMessage(message: Message) {
    alert(message.textMessage);
  }


}
