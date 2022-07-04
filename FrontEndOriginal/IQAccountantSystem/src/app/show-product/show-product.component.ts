import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProductDTO } from '../Models/ProductDTO';
import { ProductService } from '../Services/product.service';
import { NgxSpinnerService } from "ngx-spinner";
import { FileService } from '../Services/file.service';
import { ignoreElements } from 'rxjs';
import { PaginationInfo } from '../Models/PaginationInfo';
import { MatDialog } from '@angular/material/dialog';
import { DeleteProductComponent } from '../sales/delete-product/delete-product.component';
import { PrintNoteComponent } from '../print-note/print-note.component';
import { PrintPdfComponent } from '../print-barcode/print-pdf.component';

@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit {

  productDto:ProductDTO[]=[]
  paginationInfo:PaginationInfo={
    pageNo:1,
    pageSize:5
  }
  constructor(private productService:ProductService,private fileService:FileService,
    private toastr:ToastrService,private spinner:NgxSpinnerService,
    public dialog: MatDialog) { }
  public static scanned:string;
  ngOnInit(): void {
    this.GetProduct();
  }
  GetProduct(){
    this.spinner.show();
    debugger;
    this.productService.Get(this.paginationInfo).subscribe(
      data=>{
        this.productDto = data;        
        this.spinner.hide();
      },error=>{
        this.spinner.hide();
       this.toastr.error(error.message);
      }
    )
  }
  Paginate(){
    this.paginationInfo.pageSize += 5;
    this.GetProduct();
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
 OpenPrintDialog(product:ProductDTO){
  this.dialog.open(PrintPdfComponent,{data:product,width:"100%"})
 }

 OpenPrintNoteDialog(product:ProductDTO){
  this.dialog.open(PrintNoteComponent,{data:product,width:"100%"});
 }
 OpenDeleteComponent(product:ProductDTO){
  this.dialog.open(DeleteProductComponent,{data:product,width:"100%",height:"100%"});
 }
 Print(){
  window.print();
 }

}




