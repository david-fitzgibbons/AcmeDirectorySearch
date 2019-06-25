import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AppMessage } from '../models/app-message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor() { }

  public messageEvents: Subject<AppMessage> = new Subject();

  emitMessage(title: string, message: string) {
    const err: AppMessage = new AppMessage(message, 'success', title);
    this.messageEvents.next(err);
  }

  emitWarning(title: string, message: string) {
    const err: AppMessage = new AppMessage(message, 'warning', title);
    this.messageEvents.next(err);
  }
}
