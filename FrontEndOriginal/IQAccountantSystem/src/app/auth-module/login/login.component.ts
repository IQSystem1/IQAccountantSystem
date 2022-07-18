import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userForm = new FormGroup({
    UserName:new FormControl(null,[Validators.required]),
    Password : new FormControl(null,[Validators.required])
  })
  constructor(private userService:UserService,private toastr:ToastrService,private router:Router) { }

  ngOnInit(): void {
  }
  login(){
    if(this.userForm.valid){
      if(this.userForm.controls["UserName"].value && this.userForm.controls["Password"].value){
        let user:User = {
          userName:this.userForm.controls["UserName"].value,
          password : this.userForm.controls["Password"].value
        }
        this.userService.Login(user).subscribe(
          data=>{
            if(data==null){
              this.toastr.error("اسم الحساب او كلمة السر خطأ");
            }else{
              localStorage.setItem("Token",data.token);
              this.router.navigate([""]);
            }
          },error=>{this.toastr.error(error.message)}
        )
      }
    }else{
      this.toastr.warning("الرجاء تعبئة جميع الحقول")
    }
  }

}
