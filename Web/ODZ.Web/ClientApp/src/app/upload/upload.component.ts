import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { DocumentService } from '../_services/document.services';
import { AlertService } from '../_services';
import { Alert, AlertType } from '../_models';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public  progress: number;
  public fileName: string;
  public loading: boolean;

  fileInfos: Observable<any>;

  @Output() public onUploadFinished = new EventEmitter();
  constructor(
    private documentService: DocumentService,
    private alertService: AlertService,
  ) { }
  ngOnInit() {
    this.progress = 0;
    this.loading = false;
    this.fileInfos = this.documentService.getAll();
  }


  public uploadFile = (files) => {
    this.progress = 0;

    if (files.length === 0) {
      return;
    }

    let filesToUpload: FileList = files;
    this.fileName = filesToUpload[0].name;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });

    this.loading = true;

      this.documentService.upload(filesToUpload.item(0), this.fileName).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress) {

          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event instanceof HttpResponse) {

          let message = `Файлът с име "${this.fileName}" беше качен успешно :)`;
          this.alertService.success(message, { autoClose: true });
          this.fileInfos = this.documentService.getAll();

          if (this.progress == 100) {
            this.loading = false
          }
        }
      },
      err => {
        this.loading = false;
        this.alertService.error(err.error.err,{ autoClose: true });
      }
    );

  }
}
