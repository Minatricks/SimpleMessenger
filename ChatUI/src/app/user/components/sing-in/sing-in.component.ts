import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  registrate(userName: string, password: string) {
    alert(userName + password);
  }
}
