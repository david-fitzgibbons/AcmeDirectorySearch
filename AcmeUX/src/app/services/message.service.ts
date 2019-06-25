import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AppMessage } from '../models/app-message';

 /**
  * Centralized bus for handling messaging throughout the system
  *
  */
@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor() { }

  /**
   * For subscribing to message events
   */
  public messageEvents: Subject<AppMessage> = new Subject();


  /**
   * Will emit a success message to all listeners
   *
   */
  emitMessage(title: string, message: string) {
    const err: AppMessage = new AppMessage(message, 'success', title);
    this.messageEvents.next(err);
  }

 /**
  * Will emit a warning message to all listeners
  *
  */
  emitWarning(title: string, message: string) {
    const err: AppMessage = new AppMessage(message, 'warning', title);
    this.messageEvents.next(err);
  }
}
