import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ProductDTO } from '../Models/ProductDTO';
import { PrintQrCodeComponent } from '../print-qr-code/print-qr-code.component';
import { FileService } from '../Services/file.service';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-print-Barcode',
  templateUrl: './print-barcode.component.html',
  styleUrls: ['./print-barcode.component.css']
})
export class PrintBarcodeComponent implements OnInit {

  @ViewChild('Card',{static:false}) el!:ElementRef ;
  

  private sub: any;
  id:number = 0;
  product:ProductDTO = {};
  barCode :any;
  barCodeImage:any;
  iqCode = "";

  constructor(private route: ActivatedRoute, private fileService:FileService,private dialog:MatDialog, private productService:ProductService) 
  {
    
  }

  ngOnInit(): void {
    this.dialog.closeAll();
    this.sub = this.route.params.subscribe(params => {
      this.iqCode = params['iqCode'];
      if(this.iqCode){
        this.fileService.GenerateBarcode(this.iqCode).subscribe(
          data=>{
          this.barCode = data;
          console.log(data)
            this.CreateImage(data);
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
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.barCodeImage = reader.result;
    }, false);
 
    if (this.barCode) {
       reader.readAsDataURL(blob);
       
    }
 }

}
