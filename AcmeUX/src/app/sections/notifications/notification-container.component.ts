import { Inject, Component, ComponentRef, OnDestroy, ViewChild, ViewContainerRef, ComponentFactoryResolver, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { NotificationComponent } from './notification.component';
import { ErrorService } from '../../services/error.service';
import { RemoveNotification } from './remove.interface';
import { MessageService } from '../../services/message.service';
import { MessageInterface } from '../../interfaces/message.interface';

/**
 * Container for managing the displaying of Notifications for
 * success, errors, or warnings
 */
@Component({
  selector: 'app-notification-container',
  templateUrl: './notification-container.component.html',
  styleUrls: ['./notification-container.component.css']
})
export class NotificationContainerComponent implements OnInit, OnDestroy, RemoveNotification {

  // Bind ViewContinerRef and ComponentFactoryResolver for dynamic creation of notification components
  @ViewChild('dynamic', { read: ViewContainerRef, static: true }) viewContainerRef: ViewContainerRef;
  private factoryResolver: ComponentFactoryResolver;
  private notificationId = 0;
  private notifications: Array<any> = [];

  private errorSubscription: Subscription;
  private messageSubscription: Subscription;

  constructor(@Inject(ComponentFactoryResolver) factoryResolver,
              private errorService: ErrorService, private messageService: MessageService) {

    this.factoryResolver = factoryResolver;
  }

  ngOnInit() {
    this.errorSubscription = this.errorService.errorEvents.subscribe(error => this.addNotification(error));
    this.messageSubscription = this.messageService.messageEvents.subscribe(msg => this.addNotification(msg));
  }

  ngOnDestroy() {
    this.errorSubscription.unsubscribe();
    this.messageSubscription.unsubscribe();
  }

  /**
   * Adds a notification component dynamically to the application. Multiple notifications
   * can exist at the same time and will display in succession
   *
   * @param notification is the notification to show - either error / message
   */
  addNotification(notification: MessageInterface) {

    // dynamically instantiate a new instance of a child notification
    const factory = this.factoryResolver.resolveComponentFactory(NotificationComponent);
    const component: ComponentRef<NotificationComponent> = factory.create(this.viewContainerRef.parentInjector);
    const componentInstance: NotificationComponent = component.instance;

    // setup bindings to be able to remove the child notifications on close
    componentInstance.index = ++this.notificationId;
    componentInstance.notificationManager = this;

    componentInstance.setData(notification.getType(), notification.getTitle(), notification.getMessage());

    // add reference of componenet to array to manage during close events
    this.notifications.push(component);


    this.viewContainerRef.insert(component.hostView);

    // force binding of dynamic property updates
    component.changeDetectorRef.detectChanges();
  }

  /**
   * Remove the notification when the close button on the child is clicked.  The
   * container acts as the manager for all dynamically created components
   */
  removeNotification(index: number) {

    const component = this.notifications.filter(x => x.instance.index === index)[0];
    const viewIndex: number = this.viewContainerRef.indexOf(component);

    this.viewContainerRef.remove(viewIndex);

    // rebuild notifications array removing the component reference that was just destroyed
    this.notifications = this.notifications.filter(x => x.instance.index !== index);
  }


}
