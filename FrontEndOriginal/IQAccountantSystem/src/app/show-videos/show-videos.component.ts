import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ImageVideo } from '../Models/Image';
import { ProductDTO } from '../Models/ProductDTO';
import { SaleDTO } from '../Models/SaleDTO';
import { ImageVideoService } from '../Services/imageVideo.service';

@Component({
  selector: 'app-show-videos',
  templateUrl: './show-videos.component.html',
  styleUrls: ['./show-videos.component.css']
})
export class ShowVideosComponent implements OnInit {


  productId = 0;
  constructor(@Inject(MAT_DIALOG_DATA) public sale: SaleDTO, private videoService:ImageVideoService,private dialog:MatDialog) { }

  videos:ImageVideo[] = [];
  ngOnInit(): void {
    console.log(this.sale)
    this.videoService.GetVideosByProductIqCode(this.sale.productIqCode).subscribe(
      data=>{
        this.videos = data;
      }
    )
    this.productId = this.sale.productId;
  }
  AddVideo(){
    this.dialog.closeAll();
  }

}
