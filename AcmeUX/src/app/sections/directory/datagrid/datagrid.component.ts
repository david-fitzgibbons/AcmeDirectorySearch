import { Component, OnInit } from '@angular/core';
import { PagerService } from '../../../services/pager.service';
import { DirectoryService } from '../directory.service';
import { Pager } from '../../../models/pager';
import { Subscription } from 'rxjs';
import { IUser } from '../../../models/user';

@Component({
  selector: 'app-datagrid',
  templateUrl: './datagrid.component.html',
  styleUrls: ['./datagrid.component.css']
})
export class DatagridComponent implements OnInit {

  constructor(private pagerService: PagerService, private directoryService: DirectoryService) {  }

  private currentData: IUser[] = [];
  private searchSubscription: Subscription;
  searchIsOngoing: boolean = false;
  pager: Pager;


  ngOnInit() {
    this.searchSubscription = this.directoryService.searchEvents.subscribe(data => {
      if (!data.isSearchOngoing) { this.updateResults(data.searchResults); }
      else { this.searchIsOngoing = true; console.log('here'); }
    });

    this.pager = this.pagerService.getPager(this.currentData);
  }

  ngOnDestroy() {
    this.searchSubscription.unsubscribe();
  }

  updateResults(searchResults: IUser[]) {
    this.currentData = searchResults;
    this.pager = this.pagerService.getPager(searchResults);
    this.searchIsOngoing = false;
  }

  changePage(page: number) {
    this.pager = this.pagerService.getPager(this.currentData, page);
  }

}
