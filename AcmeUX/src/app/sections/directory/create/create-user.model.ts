export class CreateUser {

  FirstName: string;
  LastName: string;
  Birthday: Date;
  Interests: string | undefined;

  Street1: string;
  Street2: string | undefined;
  City: string;
  State: string;
  Zip: string;

  ImageType: string | undefined;
  ImageData: string | undefined;

  constructor() { }


}
