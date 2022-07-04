import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ProductDTO } from '../Models/ProductDTO';
import { FileService } from '../Services/file.service';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-print-pdf',
  templateUrl: './print-pdf.component.html',
  styleUrls: ['./print-pdf.component.css']
})
export class PrintPdfComponent implements OnInit {

  @ViewChild('Card',{static:false}) el!:ElementRef ;
  

  private sub: any;
  id:number = 0;

  constructor(private route: ActivatedRoute, private productService:ProductService, private fileService:FileService,
    @Inject(MAT_DIALOG_DATA) public product:ProductDTO) 
  {
    
  }

  ngOnInit(): void {
    if(this.product.productIqCode){
      this.fileService.GenerateBarcode(this.product.productIqCode).subscribe(
        data=>{
        this.product.barcode = data;
          this.CreateImage(this.product);
        }
      )
    }
  }
      
  

  Print(){
    window.print();

  }

  CreateImage(product: ProductDTO) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       product.barcodeImage = reader.result;
    }, false);
 
    if (product.barcode) {
       reader.readAsDataURL(product.barcode);
       
    }
 }

}
