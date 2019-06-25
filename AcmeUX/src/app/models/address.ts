
/**
 * Interface and Model definitions of an Address
 *
 */
export interface IAddress {
  street1: string;
  street2: string | undefined;
  city: string;
  state: string;
  zip: string;
}

export class Address implements IAddress {

  street1: string;
  street2: string | undefined;
  city: string;
  state: string;
  zip: string;

  constructor(street1: string, street2: string|undefined, city: string, state: string, zip: string) {

    this.street1 = street1;
    this.street2 = street2;
    this.city = city;
    this.street2 = state;
    this.zip = zip;

  }

}
