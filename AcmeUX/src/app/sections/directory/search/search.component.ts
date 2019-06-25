import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { DirectoryService } from '../directory.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent  {

  constructor(private directoryService: DirectoryService) { }

  private searchUpdatedObservable;

  /**
   *
   * Handle the Search Bar text updates as a user is typing.  Debounce the input
   * to delay back-end searching until the user has stopped typing.
   *
   * @param search string containing spaces to delineate search terms
   */
  onSearchUpdated(newSearchValue: string) {

    this.directoryService.emitSearchState(true);

    // instantiate the observable if not already created
    if (!this.searchUpdatedObservable) {
      Observable.create(observer => { this.searchUpdatedObservable = observer; })
        .pipe(debounceTime(2000), distinctUntilChanged())  // debounce input and only continue if text is unique
        .pipe(switchMap((sourceValue) => this.directoryService.searchUsers(<string>sourceValue)))
        .subscribe();
    }
    
    this.searchUpdatedObservable.next(newSearchValue);

  }


}
