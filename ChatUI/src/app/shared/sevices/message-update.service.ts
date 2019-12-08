import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageUpdateService {
 private channel = new Subject<boolean>();
 public channel$ = this.channel.asObservable();

 pushUpdateMessage(pushed: boolean) {
   this.channel.next(pushed);
 }
}
