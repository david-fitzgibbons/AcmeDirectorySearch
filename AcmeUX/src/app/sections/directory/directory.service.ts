import { Injectable } from '@angular/core';
import { UserService } from '../../services/user.service';
import { PropertyService } from '../../services/property.service';
import { CreateUser } from './create/create-user.model';
import { CreateUserDTO } from '../../dto/createuser.dto';
import { MessageService } from '../../services/message.service';
import { Observable } from 'rxjs';
import { IUser } from '../../models/user';
import { ErrorService } from '../../services/error.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DirectoryService {

  constructor(private userService: UserService,
    private propertyService: PropertyService,
    private messageService: MessageService,
    private errorService: ErrorService) { }

  get states():Observable<string[]> { return this.propertyService.getStates(); }

  createUser(userData: CreateUser): Observable<IUser> {
    let dto = new CreateUserDTO(
      userData.FirstName, userData.LastName, userData.Birthday, userData.Interests,
      userData.Street1, userData.Street2, userData.City, userData.State, userData.Zip,
      userData.ImageType, userData.ImageData);

    return this.userService.createUser(dto);
  }

  emitMessage(title: string, message: string) {
    this.messageService.emitMessage(title, message);
  }

  emitWarning(title: string, message: string) {
    this.messageService.emitWarning(title, message);
  }

  emitError(error: HttpErrorResponse) {
    this.errorService.emitServerError(error);
  }
}
