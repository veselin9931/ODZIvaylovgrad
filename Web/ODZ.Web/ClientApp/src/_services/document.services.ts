import { Injectable } from '@angular/core';
import { HttpEventType, HttpRequest, HttpEvent, HttpHeaders } from "@angular/common/http";
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Document } from '../_models/document';
import { environment } from '../environments/environment';


@Injectable({ providedIn: 'root' })
export class DocumentService {

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  document: Document[];
  public documents = [];

  upload(file: File, filleName: string): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();

    formData.append('file', file);

    const req = new HttpRequest('POST', `${environment.apiUrl}/api/document/${filleName}`, formData, {
      reportProgress: true,
      responseType: 'json'
    });
    return this.http.request(req);
  }

  getAll()  {
    return this.http.get(`${environment.apiUrl}/api/document`)
      .pipe(map((data: any[]) => {
        this.documents = data;
        this.documents = Object.keys(data).map(function (nameIndex) {
          let items = data[nameIndex];
          return items;
        })
        return true;
      }))
  }

  getById(id: number): Observable<HttpEvent<any>>{
    const req = new HttpRequest("GET", `${environment.apiUrl}/api/document/${id}`, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }

  deleteById(id: number): Observable<HttpEvent<any>> {
    const req = new HttpRequest("DELETE", `${environment.apiUrl}/api/document/${id}`, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }


}
