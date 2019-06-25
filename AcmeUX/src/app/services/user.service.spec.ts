import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserService } from './user.service';
import { environment } from './../../environments/environment';

describe('UserService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [UserService],
    imports: [
      HttpClientTestingModule
    ]
  }));

  afterEach(inject([HttpTestingController], (httpMock: HttpTestingController) => {
    httpMock.verify();
  }));

  it('should be created', () => {
    const service: UserService = TestBed.get(UserService);
    expect(service).toBeTruthy();
  });

  it('expects servie to return a single user with same id',
    inject([HttpTestingController, UserService],
      (httpMock: HttpTestingController, service: UserService) => {

        const tmp = { id: 1, firstname: 'test', lastname: 'test' };
        const id = 1;

        // check return value from mock controller
        service.getUser(id).subscribe(usr => {
          expect(usr).toBeDefined();
          expect(usr.id).toBe(id);
        });

        const req = httpMock.expectOne(environment.apiUrl + `${id}`);
        expect(req.request.method).toEqual('GET');

        req.flush({ data: tmp });

    }));

});
