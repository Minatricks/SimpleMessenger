import { Component, OnInit } from '@angular/core';
import { ContactViewModel } from '../../models/contact-view-model';
import { ContactService } from '../../services/contact.service';
import { ContactResponse } from '../../models/contact-response';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  contacts: Array<ContactViewModel>;

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.getContacts();
  }

  getContacts() {
    this.contactService.getMyContacts().subscribe(
      (response: ContactResponse) => {
        response.data.forEach(id => {
          this.contactService.addToCache(new ContactViewModel(id.friendId));
        });
        this.contacts = this.contactService.getFromCache();
      }
    );
  }

}
