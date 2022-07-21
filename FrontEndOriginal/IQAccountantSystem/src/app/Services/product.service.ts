import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductController } from '../EnumsUrl/ProductController';
import { Product } from '../Models/Product';
import { ProductDTO } from '../Models/ProductDTO';
import { SuccessMessage } from '../Models/SuccessMessage';
import { PaginationInfo } from '../Models/PaginationInfo';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  Get(paginationInfo:PaginationInfo):Observable<ProductDTO[]>{
    console.log(ProductController.getByCode.toString());
    console.log(paginationInfo);
    
    return this.http.post<ProductDTO[]>(ProductController.getByCode.toString(),paginationInfo);
  }
  GetById(id:number):Observable<ProductDTO>{
    return this.http.get<ProductDTO>(ProductController.get.toString()+id.toString());
  }
  Post(product:ProductDTO):Observable<Product>{
    const url = ProductController.post.toString();
    return this.http.post<Product>(url,product);
  }
  Put(product:ProductDTO):Observable<SuccessMessage>{
    return this.http.put<SuccessMessage>(ProductController.put.toString(),product);
  }
  Delete(id:number):Observable<SuccessMessage>{
    return this.http.delete<SuccessMessage>(ProductController.delete.toString()+id.toString());
  }

  GetByProductCode(code:string):Observable<ProductDTO[]>
  {
    return this.http.get<ProductDTO[]>(ProductController.getByCode.toString()+code)
  }

  Search(productDTO:ProductDTO):Observable<ProductDTO[]>{
    return this.http.post<ProductDTO[]>(ProductController.search.toString(),productDTO)
    
  }
}
