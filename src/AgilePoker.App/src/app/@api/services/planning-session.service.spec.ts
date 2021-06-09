import { TestBed } from '@angular/core/testing';

import { PlanningSessionService } from './planning-session.service';

describe('PlanningSessionService', () => {
  let service: PlanningSessionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlanningSessionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
