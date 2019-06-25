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


/**
 * Service used by the Directory components for
 * abstracting the different service layers within
 * the application
 */
@Injectable({
  providedIn: 'root'
})
export class DirectoryService {

  constructor(private userService: UserService,
              private propertyService: PropertyService,
              private messageService: MessageService,
              private errorService: ErrorService) { }


  private lastSearch = '';
  public searchEvents: Subject<SearchState> = new Subject();


  // Returns a list of states
  get states(): Observable<string[]> { return this.propertyService.getStates(); }

  // Handles the communication of the DTO to the UserService layer for create
  createUser(userData: CreateUser): Observable<IUser> {
    const dto = new CreateUserDTO(
      userData.FirstName, userData.LastName, userData.Birthday, userData.Interests,
      userData.Street1, userData.Street2, userData.City, userData.State, userData.Zip,
      userData.ImageType, userData.ImageData);

    return this.userService.createUser(dto);
  }

  // SEARCH FUNCTIONS

  /**
   * Rerun the last search
   */
  rerunLastSearch() {
    this.searchUsers(this.lastSearch).subscribe();
  }

  /**
   * Runs the search against the UserService and
   * manages emitting the events that indicate to
   * the other components that status of the search
   *
   * @param search is a space separated string of search terms
   */
  searchUsers(search: string): Observable<IUser[]> {

    this.emitSearchState(true);
    this.lastSearch = search;

    // split the search based on space
    let filters: string[] = [];
    if (search.trim().length) {
      filters = search.split(' ');
    }

    return this.userService.getUsers(filters)
      .pipe(tap(data => this.emitSearchState(false, data)));
  }

  /**
   * Emit the event that a search is in progress or has completed
   *
   * @param isSearchOngoing indicates that a search has started / not yet completed
   * @param results are the results of the search or an empty array
   */
  emitSearchState(isSearchOngoing: boolean, results: IUser[] = []) {
    const state: SearchState = new SearchState(isSearchOngoing, results);
    this.searchEvents.next(state);
  }


  // MESSAGE FUNCTIONS

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
