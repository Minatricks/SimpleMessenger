import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../../models/message';
import { MessageService } from '../../services/message.service';
import { UserService } from 'src/app/user/services/user.service';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { MessageUpdateService } from 'src/app/shared/sevices/message-update.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent {
  constructor(
    private coockieService: CookieService,
    private messageService: MessageService,
    private messageUpdateService: MessageUpdateService) { }

  sendMessage(messageText: string): void {
    const message = this.createMessage(messageText);
    this.messageService.sendMessage(message).subscribe(
      (data: any) => {
        this.messageUpdateService.pushUpdateMessage(true);
      }
    );
    this.clearInput();
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

  private clearInput() {
    (<HTMLInputElement>document.getElementById('text-area')).value = '';
  }
}
