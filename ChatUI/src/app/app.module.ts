import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { SingUpComponent } from './user/components/sing-up/sing-up.component';
import { SingInComponent } from './user/components/sing-in/sing-in.component';
import { MessageComponent } from './messages/components/message/message.component';
import { ContactsComponent } from './messages/components/contacts/contacts.component';
import { ContactComponent } from './messages/components/contact/contact.component';
import { MessageViewComponent } from './messages/components/message-view/message-view.component';
import { HttpClientModule } from '@angular/common/http';
import { MenuComponent } from './user/components/menu/menu.component';


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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
