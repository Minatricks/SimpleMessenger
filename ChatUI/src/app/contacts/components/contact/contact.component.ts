import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { MessageService } from 'src/app/messages/services/message.service';
import { Message } from 'src/app/messages/models/message';
import { UserModel } from 'src/app/user/models/user-model';
import { MessageUpdateService } from 'src/app/shared/sevices/message-update.service';
import { ContactModel } from '../../models/contact-model';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  @Input()
  contact: ContactModel;

  @Output()
  setActive: EventEmitter<number> = new EventEmitter<number>();

  constructor(private coockieService: CookieService,
    private messageService: MessageService,
    private messageUpdateService: MessageUpdateService) { }

  ngOnInit() {
  }

  onCardClick() {
    this.coockieService.setCookie(CoockieConstants.currentContactId, this.contact.id.toString(),
      { 'max-age': 3600 });
    this.messageService.getMessages().subscribe(
      (data: Message[]) => {
        this.messageUpdateService.pushUpdateMessage(true);
      }
    );
    this.setActive.emit(this.contact.id);
  }

}
