import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

export class BaseHttpService<T> {

  protected readonly baseUrl: string;

  constructor(
    protected httpClient: HttpClient,
    protected controllerPath: string) {
      this.baseUrl = environment.baseApiUrl + this.controllerPath + '/' ;
    }

  public GetSingle(url: string): Observable<T> {
    return this.httpClient.get<T>(url);
  }

  public GetList(url: string): Observable<T[]> {
    return this.httpClient.get<T[]>(url);
  }

  public GetByGuid(guid: string): Observable<T> {
    return this.httpClient.get<T>(this.baseUrl + guid);
  }

  public GetAll(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.baseUrl + 'all');
  }
}

