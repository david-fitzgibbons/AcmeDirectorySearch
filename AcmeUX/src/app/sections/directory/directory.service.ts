import { Injectable } from '@angular/core';
import { UserService } from '../../services/user.service';
import { PropertyService } from '../../services/property.service';
import { CreateUser } from './create/create-user.model';
import { CreateUserDTO } from '../../dto/createuser.dto';
import { MessageService } from '../../services/message.service';
import { Observable, Subject } from 'rxjs';
import { IUser } from '../../models/user';
import { ErrorService } from '../../services/error.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SearchState } from './search.state';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DirectoryService {

  constructor(private userService: UserService,
    private propertyService: PropertyService,
    private messageService: MessageService,
    private errorService: ErrorService) { }


  private lastSearch: string = '';
  public searchEvents: Subject<SearchState> = new Subject();



  get states():Observable<string[]> { return this.propertyService.getStates(); }

  createUser(userData: CreateUser): Observable<IUser> {
    let dto = new CreateUserDTO(
      userData.FirstName, userData.LastName, userData.Birthday, userData.Interests,
      userData.Street1, userData.Street2, userData.City, userData.State, userData.Zip,
      userData.ImageType, userData.ImageData);

    return this.userService.createUser(dto);
  }

  rerunLastSearch() {
    this.searchUsers(this.lastSearch).subscribe();
  }

  searchUsers(search: string): Observable<IUser[]> {

    this.emitSearchState(true);
    this.lastSearch = search;

    let filters:string[] = [];
    if (search.trim().length) {
      filters = search.split(' ')
    }

    return this.userService.getUsers(filters)
      .pipe(tap(data => this.emitSearchState(false, data)));
  }

  emitSearchState(isSearchOngoing: boolean, results: IUser[] = []) {
    const state: SearchState = new SearchState(isSearchOngoing, results);
    this.searchEvents.next(state);
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
