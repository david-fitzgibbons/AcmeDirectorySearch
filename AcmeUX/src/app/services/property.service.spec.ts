import { TestBed } from '@angular/core/testing';

import { PropertyService } from './property.service';

describe('PropertyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PropertyService = TestBed.get(PropertyService);
    expect(service).toBeTruthy();
  });

 /* it ('should get a list of states', () => {
    const service: PropertyService = TestBed.get(PropertyService);
    service.getStates().subscribe(data => {
      expect(data)

    });*/
});
