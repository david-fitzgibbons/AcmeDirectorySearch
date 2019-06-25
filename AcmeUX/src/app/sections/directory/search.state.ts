import { IUser } from '../../models/user';

export class SearchState {

  isSearchOngoing: boolean;
  searchResults: IUser[] | undefined;

  constructor(searchOngoing: boolean, results: IUser[]|undefined) {
    this.isSearchOngoing = searchOngoing;
    this.searchResults = results;
  }
}
