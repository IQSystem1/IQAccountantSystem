import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HostUrl } from '../EnumsUrl/HostUrl';
import { Token } from '../Models/Token';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) {

   }
   Login(user:User):Observable<Token>{
    return this.http.post<Token>(HostUrl.hostUrl+ HostUrl.user,user)
   }
   LoggedIn(){
    return !!localStorage.getItem("Token");
   }
   getToken(){
    if(this.LoggedIn())
      return localStorage.getItem("Token");
    else
      return "";
   }
}
