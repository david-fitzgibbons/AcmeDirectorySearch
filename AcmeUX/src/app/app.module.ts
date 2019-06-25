import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { GlobalErrorHandler } from './global-error.service';
import { NotificationContainerComponent } from './sections/notifications/notification-container.component';
import { NotificationComponent } from './sections/notifications/notification.component';
import { MenuComponent } from './sections/menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    NotificationContainerComponent,
    NotificationComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [{ provide: ErrorHandler, useClass: GlobalErrorHandler }],
  bootstrap: [AppComponent],
  entryComponents: [NotificationComponent]
})
export class AppModule { }
