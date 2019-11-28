import { Component, OnInit, Input } from '@angular/core';
import { Message } from '../../models/message';

@Component({
  selector: 'app-message-model',
  templateUrl: './message-model.component.html',
  styleUrls: ['./message-model.component.css']
})
export class MessageModelComponent implements OnInit {
  @Input()
  message: Message;

  constructor() { }

  ngOnInit() {
  }

}
