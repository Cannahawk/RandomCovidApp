import { Injectable } from '@angular/core';
import { Country } from 'src/app/models/country';
import { BaseHttpService } from '../base-http-service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends BaseHttpService<Country> {

  constructor(httpClient: HttpClient) {
    super(httpClient, 'country');
  }

  public GetByGuidComplete(guid: string): Observable<Country> {
    return this.httpClient.get<Country>(this.baseUrl + 'complete/' + guid);
  }

  public GetAllComplete(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(this.baseUrl + 'complete/all');
  }
}
