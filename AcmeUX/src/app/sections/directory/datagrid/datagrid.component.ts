import { Component, OnInit, OnDestroy } from '@angular/core';
import { PagerService } from '../../../services/pager.service';
import { DirectoryService } from '../directory.service';
import { Pager } from '../../../models/pager';
import { Subscription } from 'rxjs';
import { IUser } from '../../../models/user';

/**
 * The DataGrid when a search is performed.  The datagrid manages the
 * current page that the user is on, the wait display while a search
 * is being performed and the creation of the datacards to display each user
 */
@Component({
  selector: 'app-datagrid',
  templateUrl: './datagrid.component.html',
  styleUrls: ['./datagrid.component.css']
})
export class DatagridComponent implements OnInit, OnDestroy {

  constructor(private pagerService: PagerService, private directoryService: DirectoryService) {  }

  private currentData: IUser[] = [];
  private searchSubscription: Subscription;
  searchIsOngoing = false;
  pager: Pager;


  ngOnInit() {
    // listen to new searchresult events
    this.searchSubscription = this.directoryService.searchEvents.subscribe(data => {
      if (!data.isSearchOngoing) { this.updateResults(data.searchResults); } else { this.searchIsOngoing = true; }
    });

    this.pager = this.pagerService.getPager(this.currentData);
  }

  ngOnDestroy() {
    this.searchSubscription.unsubscribe();
  }

  /**
   * When new search results come in, update the pager
   * and the grid
   */
  updateResults(searchResults: IUser[]) {
    this.currentData = searchResults;
    this.pager = this.pagerService.getPager(searchResults);
    this.searchIsOngoing = false;
  }

  /**
   * Manage navigating the set of paged data
   */
  changePage(page: number) {
    this.pager = this.pagerService.getPager(this.currentData, page);
  }

}
