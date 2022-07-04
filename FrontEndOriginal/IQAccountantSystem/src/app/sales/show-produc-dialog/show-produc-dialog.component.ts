import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ImageVideo } from 'src/app/Models/Image';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { PrintPdfComponent } from 'src/app/print-barcode/print-pdf.component';
import { ImageVideoService } from 'src/app/Services/imageVideo.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-show-produc-dialog',
  templateUrl: './show-produc-dialog.component.html',
  styleUrls: ['./show-produc-dialog.component.css']
})
export class ShowProducDialogComponent implements OnInit {

  products:ProductDTO[] = [];
  videos:ImageVideo[] = [];
  constructor(@Inject(MAT_DIALOG_DATA) public product:ProductDTO, private productService:ProductService,
  private videoService:ImageVideoService,private dialog:MatDialog, private router:Router) { }

  ngOnInit(): void {
    if(this.product.productCode){
      this.productService.GetByProductCode(this.product.productCode).subscribe(
        data=>{
   

          data.forEach((product:ProductDTO)=>{
            if(product.videoUrl)
              this.products.push(product);
          })
        },error=>{
          
        }
      )
    }else if(this.product.productIqCode){
      
      this.products.push(this.product);
    }
    
  }
  OpenPrintDialog(product:ProductDTO){
    this.dialog.open(PrintPdfComponent,{data:product})
  }

  WatchVideo(videoUrl:string|undefined){
      //window.open(videoUrl, "_blank", "height=500,width=1000");
      const popup = window.open(
        videoUrl,
        '_blank',
        "height=500,width=1000"
      )?.moveTo(2500, 50);
  }

  navigateWithState(product:ProductDTO) {
    this.router.navigate(['/video/'+product.videoUrl]);

  }

}
