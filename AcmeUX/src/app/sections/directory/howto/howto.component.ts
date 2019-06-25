import { Component } from '@angular/core';

/**
 * Handles the information popup on how to utilize the Directory Search
 */
@Component({
  selector: 'app-howto',
  templateUrl: './howto.component.html'
})
export class HowtoComponent {

  constructor() { }

  // toggle modal popup displaying help text
  private isDialogVisible = false;

}
