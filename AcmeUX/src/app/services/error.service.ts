import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Subject } from 'rxjs';
import { AppError } from '../models/app-error';


/**
 * Centralized bus for handling errors within the system
 *
 */
@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor() { }

  readonly clientErrorType: string = 'Client Error';
  readonly serverErrorType: string = 'Message Received from Server';

  public errorEvents: Subject<AppError> = new Subject();

  /**
   * Will emit a Client Error occurred to all listeners
   *
   */
  emitClientError(error: Error) {
    console.log('From Error App :: ', error);
    const err: AppError = new AppError(error.message, 'danger', this.clientErrorType, error.stack);
    this.errorEvents.next(err);
  }

  /**
   * Will emit a Server Error occurred to all listeners
   *
   */
  emitServerError(error: HttpErrorResponse) {

    let msg: string = error.status + ': ' + error.message;

    if (error.error && error.error.Errors) {
      msg = '';
      for (const key of Object.keys(error.error.Errors)) {
        msg += `${key}`;
      }
    }

    const err: AppError = new AppError(msg, 'danger', this.serverErrorType);
    this.errorEvents.next(err);
  }

}
