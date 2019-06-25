import { Component, OnInit } from '@angular/core';
import { PropertyService } from '../../../services/property.service';
import { CreateUser } from './create-user.model';
import { FormGroup } from '@angular/forms';
import { MessageService } from '../../../services/message.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(private propertyService: PropertyService, private messageService: MessageService) { }


  get diagnostic() { return JSON.stringify(this.newUser); }

  form: FormGroup;

  private isDialogVisible = false;
  private states: string[] = [];

  private newUser: CreateUser = new CreateUser();

  ngOnInit() {
    this.propertyService.getStates().subscribe((data: string[]) => this.states = data);
  }

  onSubmit() {
    console.log(this.diagnostic);
  }

  resetUserData() {
    this.newUser = new CreateUser();
  }

  onFileChange(event) {
    const reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        if (file.type != 'image/png' && file.type != 'image/jpeg') {
          console.log(file);
          event.target.value = '';
          this.messageService.emitWarning('Invalid Picture Format Selected', 'Only PNG and JPEG images for users are supported at this time');
        } else {
          this.newUser.imageType = file.type;
          this.newUser.imageData = ((reader.result) as string).split(',')[1];
        }
      };
    }
  }

}
