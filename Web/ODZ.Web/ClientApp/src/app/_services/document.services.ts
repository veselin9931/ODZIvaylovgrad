import { Injectable } from '@angular/core';
import { HttpEventType, HttpRequest, HttpEvent } from "@angular/common/http";
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DocumentService {

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  upload(file: File, filleName: string): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();

    formData.append('file', file);

    const req = new HttpRequest('POST', `${environment.apiUrl}/api/document/${filleName}`, formData, {
      reportProgress: true,
      responseType: 'json'
    });


    return this.http.request(req);

  }

  getAll(): Observable<any> {
    return this.http.get(`${environment.apiUrl}api/documents`);
  }
}
