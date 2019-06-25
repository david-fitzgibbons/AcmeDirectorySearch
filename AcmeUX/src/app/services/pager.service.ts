import { Injectable } from '@angular/core';
import { Pager } from '../models/pager';

@Injectable({
  providedIn: 'root'
})
export class PagerService {

  readonly pageSize: number = 8;

  constructor() { }

  getPager(items:Array<any>, page: number = 1): Pager {

    if (page <= 0) page = 1;

    // check to see if the total pages available is smaller than the current page
    let totalPages = Math.ceil(items.length / this.pageSize);
    if (page > totalPages) page = 1;

    let start = (page - 1) * this.pageSize;
    let end = start + this.pageSize;

    if (end > items.length) end = items.length;

    //return result as a Pager ModelS
    let result: Pager = new Pager(page, totalPages, items.slice(start, end));
    return result;

  }
}
