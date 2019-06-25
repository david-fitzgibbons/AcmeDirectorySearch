import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Subject } from 'rxjs';
import { AppError } from '../models/app-error';



@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor() { }

  readonly clientErrorType: string = "Client Error";
  readonly serverErrorType: string = "Message Received from Server";

  public errorEvents: Subject<AppError> = new Subject();

  emitClientError(error: Error) {
    console.log("From Error App :: ", error);
    let err: AppError = new AppError(error.message, 'danger', this.clientErrorType, error.stack);
    this.errorEvents.next(err);
  }

  emitServerError(error: HttpErrorResponse) {
 
    let msg: string = error.status + ": " + error.message;

    if (error.error && error.error.Errors) {
      msg = '';
      for (let key in error.error.Errors) {
        msg += `${key}`
      }
    }

    let err: AppError = new AppError(msg, 'danger', this.serverErrorType);
    this.errorEvents.next(err);
  }

}
