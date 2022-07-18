import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../Services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private userService:UserService,private router:Router){}
  canActivate(): boolean {
    if(this.userService.LoggedIn()){
      return true;
    }else{
      this.router.navigate(["log"])
      return false;
    }
  }
  
}
