import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ImageVideo } from 'src/app/Models/Image';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { PrintBarcodeComponent } from 'src/app/print-barcode/print-barcode.component';
import { FileService } from 'src/app/Services/file.service';
import { ImageVideoService } from 'src/app/Services/imageVideo.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-show-produc-dialog',
  templateUrl: './show-product-dialog.component.html',
  styleUrls: ['./show-product-dialog.component.css']
})
export class ShowProductDialogComponent implements OnInit {

  barcode:any;
  qrcode:any;
  products:ProductDTO[] = [];
  videos:ImageVideo[] = [];
  constructor(@Inject(MAT_DIALOG_DATA) public product:ProductDTO, private productService:ProductService,
  private videoService:ImageVideoService,private dialog:MatDialog, private router:Router, private fileService:FileService) { }

  ngOnInit(): void {
      
    let videos = document.getElementsByTagName("video") as  HTMLCollectionOf<HTMLVideoElement>;
   

    this.GenerateBarcode();
    this.GenerateQrcode();
    debugger;
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
    this.dialog.open(PrintBarcodeComponent,{data:product})
  }

  WatchVideo(productIqCode?:string){
      window.open("video/"+productIqCode, "_blank", "height=500,width=1000");
  }



  GenerateQrcode(){
    if(this.product.productIqCode){
      this.fileService.GenerateQrCode(this.product.productIqCode).subscribe(
        data=>{
        this.product.qrcode = data;
          this.CreateQrcodeImage(this.product);
        }
      )
    }
    
  }
  GenerateBarcode(){
    if(this.product.productIqCode){
      this.fileService.GenerateBarcode(this.product.productIqCode).subscribe(
        data=>{
        this.product.barcode = data;
          this.CreateBarcodeImage(this.product);
        }
      )
    }
    
  }

  
  CreateBarcodeImage(product: ProductDTO) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.barcode = reader.result;
       console.log(product.barcodeImage)
    }, false);
 
    if (product.barcode) {
       reader.readAsDataURL(product.barcode);
       console.log(product.barcode)
       
    }

 }
 CreateQrcodeImage(product: ProductDTO) {
  let reader = new FileReader();
  reader.addEventListener("load", () => {
     this.qrcode = reader.result;
  }, false);

  if (product.qrcode) {
     reader.readAsDataURL(product.qrcode);
     console.log(product.qrcode)
  }
  

}

  

}
