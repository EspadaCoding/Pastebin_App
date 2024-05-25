import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrl: './upload.component.css'
})
export class UploadComponent implements OnInit {

  
  
  @Output() public onUploadFinished = new EventEmitter();
  
  constructor(private http: HttpClient) { }
  ngOnInit() {
  }
  
  public progress: number;
  public message: string;
  public uploadFile = (files) => { 
    if (files.length === 0) { 
      return;
    } 
    
    let fileToUpload = <File>files[0];
    const formData = new FormData();   
    formData.append('file', fileToUpload, fileToUpload.name);
    
    this.http.post('https://localhost:44362/api/upload', formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => { 
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / Number(event.total));
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      });

      alert("Name =>" + fileToUpload.name);
      console.log(formData);
  } 
}