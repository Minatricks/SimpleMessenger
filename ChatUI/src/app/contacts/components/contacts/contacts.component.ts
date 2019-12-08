import { Component, OnInit, OnDestroy } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { MessageService } from 'src/app/messages/services/message.service';
import { Message } from 'src/app/messages/models/message';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';
import { ContactModel } from '../../models/contact-model';
import { UserModel } from 'src/app/user/models/user-model';
import { concat, Subscription } from 'rxjs';
import { MessageUpdateService } from 'src/app/shared/sevices/message-update.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit, OnDestroy {
  private sub: Subscription;
  contacts: Array<ContactModel>;

  constructor(
    private contactService: ContactService,
    private messageService: MessageService,
    private messageUpdateService: MessageUpdateService,
    private coockieService: CookieService) { }

  ngOnInit() {
    this.contacts = [];
    this.messageService.onGetMessage();
    this.getContacts();
    this.sub = this.messageUpdateService.channel$.subscribe(
      (IsNeedUpdate: boolean) => {
        if (IsNeedUpdate) {
          this.getLastMessage();
        }
      }
    );
  }

  getContacts() {
    this.contactService.getMyContacts().subscribe(
      (response: Array<UserModel>) => {
        response.forEach(userModel => {
          const contact = new ContactModel();
          contact.id = userModel.id;
          contact.userName = userModel.username;
          this.contacts.push(contact);
        });
      },
      (error) => (console.log(error.message)),
      () => { this.getLastMessage(); }
    );
  }

  private getLastMessage() {
    const currentUserId = Number(this.coockieService.getCookie(CoockieConstants.id));
    this.contacts.forEach(contact => {
      this.messageService.getLastMessage(currentUserId, contact.id).subscribe(
        (data: Message) => (contact.lastMessage = data));
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onSetActive(contactId: number): void {
    this.contacts.forEach(contact => {
      contact.isActiveContact = false;
      if (contact.id === contactId) {
        contact.isActiveContact = true;
      }
    });
  }
}
