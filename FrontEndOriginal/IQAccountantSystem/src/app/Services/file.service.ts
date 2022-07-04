import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { FileController } from '../EnumsUrl/FileController';
import { BarcodeDTO } from '../Models/BarcodeDTO';
import { SuccessMessage } from '../Models/SuccessMessage';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  
  constructor(private http: HttpClient) { }
  
  Upload(selectedFile:File):Observable<SuccessMessage> {
    debugger;
    const formData = new FormData();
    formData.append('file', selectedFile);
    return this.http.post<SuccessMessage>(FileController.post.toString(),formData,{
      reportProgress: true,
    })
  }

  GenerateBarcode(code:string):Observable<Blob>{
    
    return this.http.get(FileController.get.toString()+code, { responseType: 'blob' });    
  } 

  GenerateQrCode(code:string):Observable<Blob>{
    
    return this.http.get(FileController.get.toString()+"Qrcode/"+code, { responseType: 'blob' });    
  } 
}
