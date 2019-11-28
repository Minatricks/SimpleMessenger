import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../../models/message';
import { MessageService } from '../../services/message.service';
import { UserService } from 'src/app/user/services/user.service';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent {
  constructor(private coockieService: CookieService, private messageService: MessageService) { }

  sendMessage(messageText: string): void {
    const message = this.createMessage(messageText);
    this.messageService.sendMessage(message).subscribe(
      (data: any) => {
        alert(data);
        this.messageService.addToCache(message);
      }
    );
  }

  private createMessage(text: string): Message {
    if (this.coockieService.getCookie(CoockieConstants.currentContactId) === undefined) {
      alert('Chose contact');
      return;
    }

    const message = new Message();
    message.textMessage = text;
    message.idSender = Number(this.coockieService.getCookie(CoockieConstants.id));
    message.idRecipient = Number(this.coockieService.getCookie(CoockieConstants.currentContactId));
    message.dateTime = new Date();

    return message;
  }


  /*
  ngOnInit(): void {
    this.messageService.onGetMessage(this.alertMessage);
  }

  sendMessage(message: Message) {
    message.idSender = Number(this.coockieService.getCookie(UserRightsConstant.id));
    this.messageService.sendMessage(message).subscribe(
      (date: any) => {
        alert(date);
      }
    );
  }

  alertMessage(message: Message) {
    alert(message.textMessage);
  }
*/
}
