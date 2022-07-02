import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HostUrl } from '../EnumsUrl/HostUrl';
import { PaginationInfo } from '../Models/PaginationInfo';
import { Sale } from '../Models/Sale';
import { SaleDTO } from '../Models/SaleDTO';
import { SaleProductDTO } from '../Models/SaleProductDTO';
import { TableCount } from '../Models/TableCount';

@Injectable({
  providedIn: 'root'
})
export class SaleService {

  constructor(private http:HttpClient) { }
  post(saleProduct:SaleProductDTO){
    return this.http.post(HostUrl.hostUrl+HostUrl.sale,saleProduct)
  }
  get(paginationInfo:PaginationInfo):Observable<SaleDTO[]>{
    return this.http.post<SaleDTO[]>(HostUrl.hostUrl.toString()+HostUrl.sale.toString()+"Get",paginationInfo);
  }
  getCount():Observable<TableCount>{
    return this.http.get<TableCount>(HostUrl.hostUrl.toString()+HostUrl.sale.toString()+"Count");
  }

  SearchByCode(code:string):Observable<SaleDTO[]>{
    return this.http.get<SaleDTO[]>(HostUrl.hostUrl.toString()+HostUrl.sale.toString()+"SearchByCode/"+code);
  }
  SearchByIqCode(code:string):Observable<SaleDTO[]>{
    return this.http.get<SaleDTO[]>(HostUrl.hostUrl.toString()+HostUrl.sale.toString()+"SearchByIqCode/"+code);
  }

}
