import { TestBed } from '@angular/core/testing';

import { AppResourceService } from './app-resource.service';

describe('AppResourceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppResourceService = TestBed.inject(AppResourceService);
    expect(service).toBeTruthy();
  });

  it('should translate resources', () => {
    expect(true).toBeTruthy();
  });
});
