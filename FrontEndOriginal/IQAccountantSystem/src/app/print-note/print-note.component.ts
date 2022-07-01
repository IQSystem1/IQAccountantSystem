import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDTO } from '../Models/ProductDTO';
import { FileService } from '../Services/file.service';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-print-note',
  templateUrl: './print-note.component.html',
  styleUrls: ['./print-note.component.css']
})
export class PrintNoteComponent implements OnInit {

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
      }
      )
    })
  }

  Print(){
    window.print();

  }

  
}
