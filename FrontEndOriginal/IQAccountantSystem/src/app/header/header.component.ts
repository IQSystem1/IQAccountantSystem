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
