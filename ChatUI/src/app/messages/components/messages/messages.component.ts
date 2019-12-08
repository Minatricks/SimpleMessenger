import { Component, OnInit, OnDestroy } from '@angular/core';
import { MessageService } from '../../services/message.service';
import { Message } from '../../models/message';
import { MessageUpdateService } from 'src/app/shared/sevices/message-update.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit, OnDestroy {
  messages: Array<Message>;
  private sub: Subscription;

  constructor(private messageService: MessageService,
    private messageUpdateService: MessageUpdateService) { }

  ngOnInit() {
    this.sub = this.messageUpdateService.channel$.subscribe(
      (IsNeedUpdate: boolean) => {
        if (IsNeedUpdate) {
          this.messageService.getMessages().subscribe((data: Message[]) => (this.messages = data));
        }
      }
    );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
