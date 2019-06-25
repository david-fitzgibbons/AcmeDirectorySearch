import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User, IUser } from '../models/user';
import { Address } from '../models/address';
import { CreateUserDTO } from '../dto/createuser.dto';
import { MessageService } from './message.service';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private errService: ErrorService,
    private msgService: MessageService) { }

  private userAPI: string = environment.apiUrl + '/v1/user';

  /**
   * Returns a specific user by id
   * @param id of the user to retrieve
   *
   * @returns observable containing User
   */
  getUser(id: number): Observable<User> {
    return this.http.get<IUser>(this.userAPI + `/${id}`)
      .pipe(map((resp) => {
        return this.userSerializer(resp);
      }));
  }

  /**
   * Returns a list of users based on filter critera
   * @param filters is string array of search terms
   *
   * @returns observable containing User[]
   */
  getUsers(filters: string[]): Observable<User[]> {

    let params = new HttpParams();
    filters.map(f => params = params.append('filter', f));

    return this.http.get<IUser[]>(this.userAPI, { params })
      .pipe(map(coll => coll.map(usr => this.userSerializer(usr) )));
  }

  /**
   * Creates a new user record
   * @param User is the new user to be created
   *
   * @returns observable containing User[]
   */
  createUser(user: CreateUserDTO): Observable<User> {

    return this.http.post<IUser>(this.userAPI, user)
      .pipe(map(resp => {
        return this.userSerializer(resp);
      }))
      .pipe(map(resp => {
        this.emitMessage('User Created', `Successfully created new user { ${resp.id} : ${resp.firstName} ${resp.lastName} }`);
        return resp;
      }));
  }

  private emitMessage(title: string, msg: string) {
    this.msgService.emitMessage(title, msg);
  }


  private userSerializer(resp: IUser): User {

    const tmpAddr = resp.address;
    const address = new Address(tmpAddr.street1, tmpAddr.street2, tmpAddr.city, tmpAddr.street2, tmpAddr.zip);

    return new User(resp.id, resp.firstName, resp.lastName, resp.birthday, resp.interests, address);
  }

}
