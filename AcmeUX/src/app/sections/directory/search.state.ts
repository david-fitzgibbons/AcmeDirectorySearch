import { IUser } from '../../models/user';

/**
 * Class for handling the search state between
 * the different components within the directory module
 */
export class SearchState {

  // Indicates that a search is in progress
  isSearchOngoing: boolean;

  // Results of a completed search
  searchResults: IUser[] | undefined;

  constructor(searchOngoing: boolean, results: IUser[]|undefined) {
    this.isSearchOngoing = searchOngoing;
    this.searchResults = results;
  }
}
