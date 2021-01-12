import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';

@Injectable()
export class DefaultHeaderInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let headers = request.headers;
    environment.defaultHeaders.forEach(header => {
      headers = headers.set(header.key, header.value);
    });

    const requestWithDefaultHeaders = request.clone({headers});
    return next.handle(requestWithDefaultHeaders);
  }
}
