import { Component, OnInit, Input, ViewContainerRef } from '@angular/core';
import { RemoveNotification } from './remove.interface';

/**
 * A dynamically created component managed by NotificationContainer
 * for displaying notifications at the Application level for
 * either errors or general messages
 *
 */
@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {

  public index: number;
  public notificationManager: RemoveNotification;

  @Input() private type: string;
  @Input() private title: string;
  @Input() private message: string;

  constructor(private viewContainerRef: ViewContainerRef) { }

  ngOnInit() {
  }

  setData(type: string, title: string, message: string) {
    this.type = type;
    this.title = title;
    this.message = message;
  }

  removeNotification() {
    this.notificationManager.removeNotification(this.index);
  }


}
