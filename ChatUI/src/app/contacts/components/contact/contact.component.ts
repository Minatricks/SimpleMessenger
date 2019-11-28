import { Component, OnInit, Input } from '@angular/core';
import { ContactViewModel } from '../../models/contact-view-model';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { MessageService } from 'src/app/messages/services/message.service';
import { Message } from 'src/app/messages/models/message';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  @Input()
  contact: ContactViewModel;

  constructor(private coockieService: CookieService, private messageService: MessageService) { }

  ngOnInit() {
  }

  onCardClick() {
    alert("Clicked");
    this.coockieService.setCookie(
      CoockieConstants.currentContactId,
      this.contact.friendId.toString(),
      { 'max-age': 3600 });

    this.messageService.getMessages().subscribe(
      (messages: Array<Message>) => {
        messages.forEach(message => this.messageService.addToCache(message));
      }
    );
  }

}
