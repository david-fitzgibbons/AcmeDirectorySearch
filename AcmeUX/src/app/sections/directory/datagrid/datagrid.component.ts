import { Component, OnInit } from '@angular/core';
import { PagerService } from '../../../services/pager.service';
import { DirectoryService } from '../directory.service';
import { Pager } from '../../../models/pager';

@Component({
  selector: 'app-datagrid',
  templateUrl: './datagrid.component.html',
  styleUrls: ['./datagrid.component.css']
})
export class DatagridComponent implements OnInit {

  private isFirstRender = false;
  private numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]; // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21
  private pager: Pager;

  constructor(private pagerService: PagerService, private directoryService: DirectoryService) { }

  ngOnInit() {
    this.pager = this.pagerService.getPager(this.numbers);
  }

  changePage(page: number) {
    this.pager = this.pagerService.getPager(this.numbers, page);
    this.apiService.search("john").subscribe(data => console.log(data));
  }

}
