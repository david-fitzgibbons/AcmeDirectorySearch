export class CreateUserDTO  {

  firstName: string;
  lastName: string;
  birthday: Date;
  interests: string | undefined;
  address: Record<string, string>;
  image: Record<string, string> | undefined;

  constructor(firstname: string, lastname: string, birthday: Date, interests: string|undefined,
              street1: string, street2: string | undefined, city: string, state: string, zip: string,
              imageType?: string|undefined, imageData?: string|undefined) {

    this.firstName = firstname;
    this.lastName = lastname;
    this.birthday = new Date(birthday);
    this.interests = interests;
    this.address = {
      street1: street1,
      street2 : street2,
      city: city,
      state: state,
      zip: zip
    };

    // Attach image record if one was provided
    if (imageType) {
      this.image = {
        type: imageType,
        base64image: imageData
      };
    }
  }


}
