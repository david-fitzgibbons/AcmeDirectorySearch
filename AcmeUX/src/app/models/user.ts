import { IAddress } from './address';

/**
 * Interface and Model definitions of an Address
 *
 */
export interface IUser {

  id: number | undefined;
  firstName: string;
  lastName: string;
  birthday: Date;
  interests: string | undefined;
  address: IAddress;

  getAge(): number;

}

export class User implements IUser {

  id: number | undefined;
  firstName: string;
  lastName: string;
  birthday: Date;
  interests: string | undefined;
  address: IAddress;

  constructor(id: number, firstname: string, lastname: string, birthday: Date, interests: string, address: IAddress) {
    this.id = id;
    this.firstName = firstname;
    this.lastName = lastname;
    this.birthday = new Date(birthday);
    this.interests = interests;
    this.address = address;
  }

  // https://stackoverflow.com/questions/4060004/calculate-age-given-the-birth-date-in-the-format-yyyymmdd?page=1&tab=votes#tab-top
  getAge(): number {

    const today = new Date();
    let age = today.getFullYear() - this.birthday.getFullYear();
    const m = today.getMonth() - this.birthday.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < this.birthday.getDate())) {
      age--;
    }

    return age;
  }
}
