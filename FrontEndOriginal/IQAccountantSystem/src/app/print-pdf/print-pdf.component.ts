import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  product:ProductDTO = {
    barcodeImage: null
  }

  private sub: any;
  id:number = 0;

  constructor(private route: ActivatedRoute, private productService:ProductService, private fileService:FileService) 
  {
    
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      console.log(this.id)
      this.productService.GetByProductCode(this.id.toString()).subscribe(
        data=>{
          this.product = data;
          if(this.product.productCode)
          this.fileService.GenerateBarcode(this.product.productCode).subscribe(
            data=>{
            this.product.barcode = data;
              this.CreateImage(this.product);
            }
          )
        console.log(this.product);
      }
      )
    })
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
