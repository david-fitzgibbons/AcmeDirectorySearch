import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  constructor(private http: HttpClient) { }

  /**
   * Returns a list of states
   *
   * @returns string[] of states
   */
  getStates(): Observable<string[]> {
    return this.http.get<string[]>(environment.apiUrl + '/v1/property/states');
  }
}
