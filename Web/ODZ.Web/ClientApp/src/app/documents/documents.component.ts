import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DocumentService } from '../../_services/document.services';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AlertService } from '../../_services';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.css']
})
export class DocumentsComponent implements OnInit {
  public loading: boolean;
  public progress: number;
  fileInfos: Observable<any>;
  public documents = [];
  url: string;

  constructor(private documentService: DocumentService, private alertService: AlertService) { this.url = environment.apiUrl }

  ngOnInit(): void {
    this.loading = true;
    this.documentService.getAll()
      .subscribe(success => {
        if (success) {
          this.documents = this.documentService.documents;
          console.log(this.documents);
        }
        this.loading = false;
      })
  } 

  downloadFile(event, document){
    console.log(event);
    console.log(document);
  }

  public deleteFile = (id: number, name: string) => {

    this.documentService.deleteById(id)
      .subscribe(
        event => {
          if (event.type === HttpEventType.UploadProgress) {

            this.progress = Math.round(100 * event.loaded / event.total);
          } else if (event instanceof HttpResponse) {

            let message = `${name} - беше премахнат успешно!`;
            this.alertService.success(message, { autoClose: true });
            this.fileInfos = this.documentService.getAll();

            if (this.progress == 100) {
              this.loading = false
            }
          }
        },
        err => {
          this.loading = false;
          this.alertService.error(err.error.err, { autoClose: true });
        }
      );
  }
}
