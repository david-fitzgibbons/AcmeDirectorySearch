import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpbaseService {

  constructor(private httpClient: HttpClient) { }

  get(version: number, api: string, queryparams: ) {
    return this.httpClient.get('something');
  }
}
