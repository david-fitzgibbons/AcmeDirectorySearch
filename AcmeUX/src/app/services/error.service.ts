import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Subject } from 'rxjs';
import { AppError } from '../models/app.error';



@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor() { }

  readonly clientErrorType: string = "Client Error";
  readonly serverErrorType: string = "Server Error";

  public errorEvents: Subject<AppError> = new Subject();

  emitClientError(error: Error) {
    console.log("From Error Service :: ", error);
    let err: AppError = new AppError(error.message, this.clientErrorType, this.clientErrorType, error.stack);
    this.errorEvents.next(err);
  }

  emitServerError(error: HttpErrorResponse) {
 
    let msg: string = error.status + ": " + error.message;

    if (error.error && error.error.Errors) {
      msg = 'Error: ';
      for (let key in error.error.Errors) {
        msg += `${key};`
      }
    }

    let err: AppError = new AppError(msg, this.serverErrorType, error.status + " " + this.serverErrorType);
    this.errorEvents.next(err);
  }

}
