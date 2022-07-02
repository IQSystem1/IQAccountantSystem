import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ImageVideoController } from '../EnumsUrl/ImageVideoController';
import { ImageVideo } from '../Models/Image';
import { SuccessMessage } from '../Models/SuccessMessage';

@Injectable({
  providedIn: 'root'
})
export class ImageVideoService {

  constructor(private http:HttpClient) { }

  GetVideosByProductCode(productCode:string):Observable<ImageVideo[]>{
    return this.http.get<ImageVideo[]>(ImageVideoController.getByProductCode.toString()+productCode);
  }

  GetVideosByProductIqCode(productCode:string):Observable<ImageVideo[]>{
    return this.http.get<ImageVideo[]>(ImageVideoController.getByProductIqCode.toString()+productCode);
  }
}
