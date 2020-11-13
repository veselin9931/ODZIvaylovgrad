import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DocumentService } from '../../_services/document.services';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.css']
})
export class DocumentsComponent implements OnInit {

  fileInfos: Observable<any>;
  public documents = [];
  constructor(private documentService: DocumentService) { }

  ngOnInit(): void {
    this.documentService.getAll()
      .subscribe(success => {
        if (success) {
          this.documents = this.documentService.documents;
        }
      })
  }

  downloadFile(event, document){
    console.log(event);
    console.log(document);
  }
}
