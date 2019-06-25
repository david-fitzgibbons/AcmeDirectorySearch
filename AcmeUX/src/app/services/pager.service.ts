import { Injectable } from '@angular/core';
import { Pager } from '../models/pager';

/**
 * PagerService allows for any array to be consumed
 * in a pageable fashion
 *
 */
@Injectable({
  providedIn: 'root'
})
export class PagerService {

  readonly pageSize: number = 8;

  constructor() { }

 /**
  * Returns a PagerModel that will sepearates a large array in to pages
  * returning the desired subset of items for the page you require
  * @param items the array of items to be paged
  * @param page the page number of the items to be returned
  *
  */
  getPager(items: Array<any>, page: number = 1): Pager {

    if (page <= 0) { page = 1; }

    // check to see if the total pages available is smaller than the current page
    const totalPages = Math.ceil(items.length / this.pageSize);
    if (page > totalPages) { page = 1; }

    const start = (page - 1) * this.pageSize;
    let end = start + this.pageSize;

    if (end > items.length) { end = items.length; }

    // return result as a Pager ModelS
    const result: Pager = new Pager(page, totalPages, items.slice(start, end));
    return result;

  }
}
