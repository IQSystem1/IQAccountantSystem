import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { takeLast } from 'rxjs';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router:Router,private userService:UserService) { }

  ngOnInit(): void {

    if(this.userService.LoggedIn()){
      let token = this.userService.getToken()
        if(token){
          if (this.tokenExpired(token)) {
            localStorage.clear();
            window.location.reload();
          } 
        }
        
      }
    }
  

  tokenExpired(token: string) {
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
  }


  logout(){
    localStorage.clear();
    this.router.navigate(["log"]);
  }

  loggedIn()
  {
    return this.userService.LoggedIn();
  }
}
