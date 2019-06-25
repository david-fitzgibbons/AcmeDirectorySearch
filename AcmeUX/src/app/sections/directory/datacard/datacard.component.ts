import { Component, Input } from '@angular/core';
import { IUser } from '../../../models/user';
import { environment } from './../../../../environments/environment';

@Component({
  selector: '[app-datacard]',
  templateUrl: './datacard.component.html',
  styleUrls: ['./datacard.component.css']
})
export class DatacardComponent {

  constructor() { }

  @Input() userData: IUser;

  get imageUrl() {
    return environment.apiUrl + `/v1/user/${this.userData.id}/image`;
  }

}
