import { Component, Inject,OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ImageVideo } from '../Models/Image';
import { ProductDTO } from '../Models/ProductDTO';
import { SaleDTO } from '../Models/SaleDTO';
import { ImageVideoService } from '../Services/imageVideo.service';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-show-videos',
  templateUrl: './show-videos.component.html',
  styleUrls: ['./show-videos.component.css']
})
export class ShowVideosComponent implements OnInit {


  productId = 0;
  constructor(@Inject(MAT_DIALOG_DATA) public sale: SaleDTO, private videoService:ImageVideoService,
  private dialog:MatDialog, private productService:ProductService,
  private spinner:NgxSpinnerService, private toastr:ToastrService) { }

  products:ProductDTO[] = [];
  videos:ImageVideo[] = [];
  ngOnInit(): void {
    // this.videoService.GetVideosByProductIqCode(this.sale.productIqCode).subscribe(
    //   data=>{
    //     this.videos = data;
    //   }
    // )
    this.productService.GetByProductCode(this.sale.productCode).subscribe(
      data=>{
        this.spinner.hide();
        data.forEach((product:ProductDTO)=>{
          if(product.videoUrl)
            this.products.push(product);
        })
      },error=>{
        this.toastr.error(error.message);
        this.spinner.hide();
        this.dialog.closeAll();
      }
    )
    this.productId = this.sale.productId;
  }
  AddVideo(){
    this.dialog.closeAll();
  }


  WatchVideo(videoUrl:string|undefined){
    window.open(videoUrl, "_blank", "height=500,width=1000");
}
}
