import { Component, OnInit } from '@angular/core';
import { CreateUser } from './create-user.model';
import { DirectoryService } from '../directory.service';

/**
 * Handles the displaying of the 'Create User' form, the
 * collection of data from the user.  On submission will
 * pass the user's data down to the DirectoryService
 */
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

  /**
   * Handles the submission of the user.  Listens to the response and will keep
   * the form open with the values provided if there is an error.  If successful,
   * will clean up the form and re-run the last search
   */
  onSubmit() {
    this.isSaving = true;
    this.directoryService.createUser(this.newUser)
      .subscribe(
        (saved) => { this.resetUserData(); this.directoryService.rerunLastSearch(); },
        (err) => { this.isSaving = false; this.directoryService.emitError(err); });
  }

  /**
   * Resets the UserData object on success / form closure
   */
  resetUserData() {
    this.newUser = new CreateUser();
    this.isSaving = false;
    this.isDialogVisible = false;
  }

  /**
   * Uses the onFileChange event of the FileInput html control to parse
   * the user provided data in to a base64 string representing the
   * image the user provided
   *
   */
  onFileChange(event) {

    const reader = new FileReader();

    // check the event for the existence of a file
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      reader.readAsDataURL(file);

      // on reading the file, check its type and format the data
      reader.onload = () => {
        if (file.type !== 'image/png' && file.type !== 'image/jpeg') {
          // if not an image, clear the field / emit warning
          event.target.value = '';
          this.directoryService.emitWarning('Invalid Picture Format Selected',
            'Only PNG and JPEG images for users are supported at this time');
        } else {
          // Get the FileType and the Base64 string representing the uploaded file
          this.newUser.ImageType = file.type;
          this.newUser.ImageData = ((reader.result) as string).split(',')[1];
        }
      };
    }
  }

}
