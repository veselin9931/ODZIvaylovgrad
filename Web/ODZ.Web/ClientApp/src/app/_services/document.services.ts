import { Injectable } from '@angular/core';
import { HttpEventType } from "@angular/common/http";
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DocumentService {

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  upload(progress: number, message: string, formData, filleName: string) {
    this.http.post(`${environment.apiUrl}/api/document/${filleName}`, formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          message = 'Upload success.';
          return  event.body
        }
      });
  }
}
