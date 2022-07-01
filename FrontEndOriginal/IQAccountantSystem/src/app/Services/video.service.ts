import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { VideoController } from '../EnumsUrl/VideoController';
import { SuccessMessage } from '../Models/SuccessMessage';
import { Video } from '../Models/Video';

@Injectable({
  providedIn: 'root'
})
export class VideoService {

  constructor(private http:HttpClient) { }

  Get():Observable<Video[]>{
    return this.http.get<Video[]>(VideoController.get.toString());
  }
  GetById(id:number):Observable<Video>{
    return this.http.get<Video>(VideoController.get.toString()+id.toString());
  }
  Post(video:Video):Observable<Video>{
    console.log(video);
    debugger;
    return this.http.post<Video>(VideoController.post.toString(),video);
  }
  Put(video:Video):Observable<SuccessMessage>{
    return this.http.put<SuccessMessage>(VideoController.put.toString(),video);
  }
  Delete(id:number):Observable<SuccessMessage>{
    return this.http.delete<SuccessMessage>(VideoController.delete.toString()+id.toString());
  }

  GetByProductId(productId:number):Observable<Video>{
    return this.http.get<Video>(VideoController.getByProductId.toString()+productId);
  }
}
