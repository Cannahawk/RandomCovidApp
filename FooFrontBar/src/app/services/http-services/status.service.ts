import { Injectable } from '@angular/core';
import { BaseHttpService } from '../base-http-service/base-http.service';
import { Status } from 'src/app/models/status';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StatusService extends BaseHttpService<Status> {
  constructor(client: HttpClient) {
    super(client, 'Status');
  }
}
