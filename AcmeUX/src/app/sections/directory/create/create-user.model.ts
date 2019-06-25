export class CreateUser {

  firstName: string;
  lastName: string;
  birthday: Date;
  interests: string | undefined;

  street1: string;
  street2: string | undefined;
  city: string;
  state: string;
  zip: string;

  imageType: string | undefined;
  imageData: string | undefined;

  constructor() { }


}
