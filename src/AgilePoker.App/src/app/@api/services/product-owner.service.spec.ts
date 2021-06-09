import { TestBed } from '@angular/core/testing';

import { ProductOwnerService } from './product-owner.service';

describe('ProductOwnerService', () => {
  let service: ProductOwnerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductOwnerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
