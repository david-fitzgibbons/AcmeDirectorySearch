import { Component, OnInit } from '@angular/core';
import { CreateUser } from './create-user.model';
import { FormGroup } from '@angular/forms';
import { DirectoryService } from '../directory.service';
import { CreateUserDTO } from '../../../dto/createuser.dto';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(private directoryService: DirectoryService) { }

  private isSaving = false;
  private isDialogVisible = false;
  private states: string[] = [];

  private newUser: CreateUser = new CreateUser();

  ngOnInit() {
    this.directoryService.states.subscribe((data: string[]) => this.states = data);
  }

  onSubmit() {
    this.isSaving = true;
    this.directoryService.createUser(this.newUser)
      .subscribe(
        (saved) => { this.resetUserData(); this.directoryService.rerunLastSearch(); },
        (err) => { this.isSaving = false; this.directoryService.emitError(err); });
  }

  resetUserData() {
    this.newUser = new CreateUser();
    this.isSaving = false;
    this.isDialogVisible = false;
  }

  onFileChange(event) {
    const reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        if (file.type !== 'image/png' && file.type !== 'image/jpeg') {
          console.log(file);
          event.target.value = '';
          this.directoryService.emitWarning('Invalid Picture Format Selected',
            'Only PNG and JPEG images for users are supported at this time');
        } else {
          this.newUser.ImageType = file.type;
          this.newUser.ImageData = ((reader.result) as string).split(',')[1];
        }
      };
    }
  }

}
