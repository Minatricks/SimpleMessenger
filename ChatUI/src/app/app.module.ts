import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { SingUpComponent } from './user/components/sing-up/sing-up.component';
import { SingInComponent } from './user/components/sing-in/sing-in.component';
import { MessageComponent } from './messages/components/message-form/message.component';
import { ContactsComponent } from './contacts/components/contacts/contacts.component';
import { ContactComponent } from './contacts/components/contact/contact.component';
import { MessageViewComponent } from './main-view/main-view/message-view.component';
import { HttpClientModule } from '@angular/common/http';
import { MenuComponent } from './user/components/menu/menu.component';
import { MessagesComponent } from './messages/components/messages/messages.component';
import { MessageModelComponent } from './messages/components/message-model/message-model.component';
import { UserService } from './user/services/user.service';
import { CookieService } from './shared/sevices/cookie.service';
import { MessageService } from './messages/services/message.service';


@NgModule({
  declarations: [
    AppComponent,
    SingUpComponent,
    SingInComponent,
    MessageComponent,
    ContactsComponent,
    ContactComponent,
    MessageViewComponent,
    MenuComponent,
    MessagesComponent,
    MessageModelComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [UserService, CookieService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
