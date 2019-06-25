/**
 * Pager model that works with the PagerService
 * for creating paged lists out of Array's
 *
 */
export class Pager {
  private pagedItemList: Array<any>;
  private totalPages: number;
  private currentPage: number;

  constructor(currentPage, totalPages, pagedItemList) {
    this.currentPage = currentPage;
    this.totalPages = totalPages;
    this.pagedItemList = pagedItemList;
  }

  getCurrentPage(): number {
    return this.currentPage;
  }

  getTotalPages(): number {
    return this.totalPages;
  }

  getPagedItemList(): Array<any> {
    return this.pagedItemList;
  }

  getTotalItems(): number {
    let result = 0;
    if (this.pagedItemList) {
      result = this.pagedItemList.length;
    }
    return result;
  }

}
