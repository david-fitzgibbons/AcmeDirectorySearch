import { Inject, Component, ComponentRef, OnDestroy, ViewChild, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { Subscription } from 'rxjs';
import { NotificationComponent } from './notification.component';
import { ErrorService } from '../../services/error.service';
import { AppError } from '../../models/app-error';
import { RemoveNotification } from './remove.interface';

/**
 * Container for managing the displaying of Notifications for
 * success, errors, or warnings
 */
@Component({
  selector: 'app-notification-container',
  templateUrl: './notification-container.component.html',
  styleUrls: ['./notification-container.component.css']
})
export class NotificationContainerComponent implements OnDestroy, RemoveNotification {

  @ViewChild('dynamic', { read: ViewContainerRef, static: true }) viewContainerRef: ViewContainerRef;
  private factoryResolver: ComponentFactoryResolver;
  private notificationId: number = 0;
  private notifications: Array<any> = [];

  private errorSubscription: Subscription;

  constructor(@Inject(ComponentFactoryResolver) factoryResolver, private errorService: ErrorService) {
    this.factoryResolver = factoryResolver;
    this.errorSubscription = errorService.errorEvents.subscribe(error => this.addErrorNotification(error));
  }

  ngOnDestroy() {
    this.errorService.errorEvents.unsubscribe();
  }

  addErrorNotification(error: AppError) {
    this.addNotification(error.getType(), error.getTitle(), error.getMessage());
  }

  addNotification(type: string, title: string, message: string, footer?: string) {

    // dynamically instantiate a new instance of a child notification
    let factory = this.factoryResolver.resolveComponentFactory(NotificationComponent);
    let component: ComponentRef<NotificationComponent> = factory.create(this.viewContainerRef.parentInjector);
    let componentInstance: NotificationComponent = component.instance;

    // setup bindings to be able to remove the child notifications on close
    componentInstance.index = ++this.notificationId;
    componentInstance.notificationManager = this;

    componentInstance.setData(type, title, message);

    // add reference of componenet to array to manage during close events
    this.notifications.push(component);


    this.viewContainerRef.insert(component.hostView);

    // force binding of dynamic property updates
    component.changeDetectorRef.detectChanges();
  }


  removeNotification(index: number) {

    let component = this.notifications.filter(x => x.instance.index == index)[0];
    let viewIndex: number = this.viewContainerRef.indexOf(component);

    this.viewContainerRef.remove(viewIndex);

    //rebuild notifications array removing the component reference that was just destroyed
    this.notifications = this.notifications.filter(x => x.instance.index != index);

    console.log(index);

  }


}