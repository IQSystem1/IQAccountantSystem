import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ImageVideo } from '../Models/Image';
import { ImageVideoService } from '../Services/imageVideo.service';


@Component({
  selector: 'app-video-page',
  templateUrl: './video-page.component.html',
  styleUrls: ['./video-page.component.css']
})
export class VideoPageComponent implements OnInit {

  private sub: any;
  videos:ImageVideo[] = [];
  productIqCode = "";
  constructor(private route: ActivatedRoute, private dialog:MatDialog,private router:Router, private videoService:ImageVideoService
    ,private spinner:NgxSpinnerService , private toastr:ToastrService) { }

  ngOnInit(): void {
    this.dialog.closeAll();
    this.spinner.show();
    this.sub = this.route.params.subscribe(params => {
      this.productIqCode = params['iqCode'];
      this.videoService.GetVideosByProductIqCode(this.productIqCode).subscribe(
        data=>{
          this.videos = data;
          console.log(this.videos)
          this.spinner.hide();
          if(!this.videos)
          {
            
          }
        },error=>{
          this.toastr.error(error.message);
          this.router.navigate(["../"]);
        }
      )
    })
    
  }

}
