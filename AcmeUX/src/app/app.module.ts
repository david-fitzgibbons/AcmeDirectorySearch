import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { GlobalErrorHandler } from './global-error.service';
import { NotificationContainerComponent } from './sections/notifications/notification-container.component';
import { NotificationComponent } from './sections/notifications/notification.component';
import { MenuComponent } from './sections/menu/menu.component';
import { AboutComponent } from './sections/about/about.component';
import { RouterModule } from '@angular/router';
import { DirectoryModule } from './sections/directory/directory.module';

@NgModule({
  declarations: [
    AppComponent,
    NotificationContainerComponent,
    NotificationComponent,
    MenuComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DirectoryModule,
    RouterModule.forRoot([
      { path: 'about', component: AboutComponent },
      { path: '**', redirectTo: '/directory' },
    ])
  ],
  providers: [{ provide: ErrorHandler, useClass: GlobalErrorHandler }],
  bootstrap: [AppComponent],
  entryComponents: [NotificationComponent]
})
export class AppModule { }
