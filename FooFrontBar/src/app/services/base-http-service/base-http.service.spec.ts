import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Country } from 'src/app/models/country';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BaseHttpService } from './base-http.service';

describe('BaseHttpService', () => {
  let service: BaseHttpService<Country>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = new BaseHttpService<Country>(TestBed.inject(HttpClient), 'Country');
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
