import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { ErrorService } from './services/error.service';


/**
 * Global Error Handler provided by:
 * https://blog.angularindepth.com/expecting-the-unexpected-best-practices-for-error-handling-in-angular-21c3662ef9e4
 *
 * Modified to use an observable ErrorService that can be subscribed to by multiple components/services
 *
 */

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private injector: Injector) { }

  handleError(error: Error | HttpErrorResponse) {

    const errorService = this.injector.get(ErrorService);

    if (error instanceof HttpErrorResponse) {
      errorService.emitServerError(error);
    } else {
      errorService.emitClientError(error);
    }
  }

}
