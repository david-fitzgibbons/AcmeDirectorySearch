import { Component } from '@angular/core';
import { PropertyService } from './services/property.service';
import { UserService } from './services/user.service';
import { User, IUser } from './models/user';
import { CreateUserDTO } from './dto/createuser.dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'acme-angular';

  constructor(private propertyService: PropertyService, private userService: UserService) { }

  testStates() {
    this.propertyService.getStates().subscribe((any: any) => console.log(any));
  }

  testGetUser() {
    this.userService.getUser(5).subscribe(this.logUser);

    this.userService.getUsers(['j', 'k']).subscribe((o) => console.log(o));

    const user = new CreateUserDTO('katie', 'hoek', new Date(), undefined, '123 main',
      undefined, 'he', 'ny', '11111');
    this.userService.createUser(user).subscribe(o => console.log('created user!: ', o));
  }

  logUser(usr: User) {
    console.log(usr.getAge());
  }
}
