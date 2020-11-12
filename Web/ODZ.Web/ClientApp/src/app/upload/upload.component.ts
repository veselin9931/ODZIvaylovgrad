import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { DocumentService } from '../_services/document.services';
import { AlertService } from '../_services';
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public progress: number;
  public message: string;
  public fileName: string

  @Output() public onUploadFinished = new EventEmitter();
  constructor(
    private http: HttpClient,
    private accountService: DocumentService,
    private alertService: AlertService
  ) { }
  ngOnInit() {
    
    
  }


  public uploadFile = (files) => {

    if (files.length === 0) {
      return;
    }
    
    let filesToUpload: File[] = files;
    this.fileName = filesToUpload[0].name;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });

    let eventBody = this.accountService.upload(this.progress, this.message, formData, this.fileName)

    this.onUploadFinished.emit(eventBody);
      
  }
}
