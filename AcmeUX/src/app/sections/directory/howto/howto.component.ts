import { Component } from '@angular/core';

@Component({
  selector: 'app-howto',
  templateUrl: './howto.component.html'
})
export class HowtoComponent {

  constructor() { }

  // toggle modal popup displaying help text
  private isDialogVisible = false;

}
