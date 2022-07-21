import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ProductVideoController } from '../EnumsUrl/ProductVideoController';
import { ProductVideo } from '../Models/ProductVideo';
import { SuccessMessage } from '../Models/SuccessMessage';

@Injectable({
  providedIn: 'root'
})
export class ProductVideoService {

  constructor(private http:HttpClient) { }

  Get():Observable<ProductVideo[]>{
    return this.http.get<ProductVideo[]>(ProductVideoController.get.toString());
  }
  GetById(id:number):Observable<ProductVideo>{
    return this.http.get<ProductVideo>(ProductVideoController.get.toString()+id.toString());
  }
  Post(product:ProductVideo):Observable<ProductVideo>{
    const url = ProductVideoController.put.toString();
    return this.http.post<ProductVideo>(ProductVideoController.post.toString(),product);
  }
  Put(product:ProductVideo):Observable<SuccessMessage>{
    
    return this.http.put<SuccessMessage>(ProductVideoController.put.toString(),product);
  }
  Delete(productVideo:ProductVideo):Observable<SuccessMessage>{
    return this.http.put<SuccessMessage>(ProductVideoController.delete.toString(),productVideo);
  }
}
