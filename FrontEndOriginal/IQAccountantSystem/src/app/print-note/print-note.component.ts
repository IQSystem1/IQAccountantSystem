import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
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
  

  private sub: any;
  id:number = 0;

  constructor(private route: ActivatedRoute, private productService:ProductService, @Inject(MAT_DIALOG_DATA) public product:ProductDTO) 
  {
    
  }

  ngOnInit(): void {
  
  }

  Print(){
    window.print();

  }

  
}
