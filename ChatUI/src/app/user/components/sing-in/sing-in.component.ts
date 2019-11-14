import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {

  constructor(private router: Router) { 
    
  }


  ngOnInit() {
  }

  registrate(userName: string, password: string) {
    alert(userName + password);
  }

  signUp() {
    this.router.navigate(['/sign-up']);
  }
}
