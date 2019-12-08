import { Component, OnInit, Input } from '@angular/core';
import { Message } from '../../models/message';
import { CookieService } from 'src/app/shared/sevices/cookie.service';
import { CoockieConstants } from 'src/app/shared/models/user-rights-constant';

@Component({
  selector: 'app-message-model',
  templateUrl: './message-model.component.html',
  styleUrls: ['./message-model.component.css']
})
export class MessageModelComponent implements OnInit {
  @Input()
  message: Message;
  IsMarginLeft: boolean;

  constructor(private coockieService: CookieService) { }

  ngOnInit() {
    let currentUserId = Number(this.coockieService.getCookie(CoockieConstants.id));
    this.IsMarginLeft = currentUserId === this.message.idSender;
  }

}
