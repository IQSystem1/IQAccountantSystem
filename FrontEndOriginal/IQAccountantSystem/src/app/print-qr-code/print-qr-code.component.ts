import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { BlobDTO } from '../Models/BlobDTO';
import { ProductDTO } from '../Models/ProductDTO';
import { FileService } from '../Services/file.service';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-print-qr-code',
  templateUrl: './print-qr-code.component.html',
  styleUrls: ['./print-qr-code.component.css']
})
export class PrintQrCodeComponent implements OnInit {

  private sub: any;
  id:number = 0;
  product:ProductDTO = {};
  qrCode :any;
  qrCodeImage:any;
  iqCode = "";
  file:any;
  constructor(private route: ActivatedRoute, private fileService:FileService,private dialog:MatDialog, private productService:ProductService) 
  {
    
  }

  ngOnInit(): void {
    this.dialog.closeAll();
    this.sub = this.route.params.subscribe(params => {
      this.iqCode = params['iqCode'];
      if(this.iqCode){
        this.fileService.GenerateQrCode(this.iqCode).subscribe(
          data=>{
          this.qrCode = data;
            this.CreateImage(data);
            let x = document.getElementById("qrImage") as HTMLImageElement;
          }
        )
      }
    })

    this.productService.Search(this.product).subscribe(
      data=>{
        this.product = data[0]
      }
    )
  }
      
  Print(){
    window.print();

  }

  CreateImage(blob:Blob) {
    console.log(blob)
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.qrCodeImage = reader.result;
    }, false);
 
    if (this.qrCode) {
       reader.readAsDataURL(blob); 
    }

 }

 Read(){
  var file = document.createElement("img") as HTMLImageElement;
  
 }
}
