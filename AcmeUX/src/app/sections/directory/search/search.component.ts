import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent  {

  constructor() { }

  private searchUpdatedObservable;

  /**
 *
 * Handle the Search Bar text updates as a user is typing.  Debounce the input
 * to delay back-end searching until the user has stopped typing.
 *
 * @param newSearchValue
 */
  onSearchUpdated(newSearchValue: string) {

    // instantiate the observable if not already created
    if (!this.searchUpdatedObservable) {
      Observable.create(observer => { this.searchUpdatedObservable = observer; })
        .pipe(debounceTime(250), distinctUntilChanged())  // debounce input and only continue if text is unique
        // .switchMap((searchValue) => searchServiceAPI.search(searchValue))
        .subscribe(console.log);
    }

    this.searchUpdatedObservable.next(newSearchValue);

  }


}
