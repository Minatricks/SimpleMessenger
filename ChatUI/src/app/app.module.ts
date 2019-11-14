import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { UserComponent } from './user/components/user/user.component';
import { SingUpComponent } from './user/components/sing-up/sing-up.component';
import { SingInComponent } from './user/components/sing-in/sing-in.component';
import { MessageComponent } from './messages/components/message/message.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SingUpComponent,
    SingInComponent,
    MessageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
