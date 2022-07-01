import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BarcodeService {

  constructor(private http: HttpClient) { }

  
  GetBarCode():Observable<Blob>{
    var imageUrl="https://localhost:44308/Barcode"
    return this.http.get(imageUrl, { responseType: 'blob' });    
  } 
}
