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
import { PrintBarcodeComponent } from '../print-barcode/print-barcode.component';
import { Product } from '../Models/Product';
import { ShowProductDialogComponent } from '../sales/show-product-dialog/show-product-dialog.component';
import { ReadQrComponent } from '../read-qr/read-qr.component';

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
  code="";
  iqCode="";

  constructor(private productService:ProductService,private fileService:FileService,
    private toastr:ToastrService,private spinner:NgxSpinnerService,
    public dialog: MatDialog) { }
  public static scanned:string;
  ngOnInit(): void {
    this.GetProduct();
  }
  GetProduct(){
    this.spinner.show();
      this.productService.Get(this.paginationInfo).subscribe(
      data=>{
        this.productDto = data;        
        console.log(this.productDto)
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
  this.dialog.open(PrintBarcodeComponent,{data:product,width:"100%"})
 }

 OpenPrintNoteDialog(product:ProductDTO){
  this.dialog.open(PrintNoteComponent,{data:product,width:"100%"});
 }
 OpenDeleteComponent(product:ProductDTO){
  // this.dialog.open(DeleteProductComponent,{data:product,width:"100%",height:"100%"});
  window.location.reload();
 }
 Print(){
  window.print();
 }


 Search(){
  this.paginationInfo.pageSize=10;
    if(isNumber(this.code)){
      let product:Product = {
        productCode:this.code
      }
        this.productService.Search(product).subscribe(
        data=>
        {
          if(data==null)
            this.toastr.warning("لا يوجد منتج بهذا الكود")
          this.dialog.open(ShowProductDialogComponent,{data:data[0],width:"100%"})
          this.productDto=data
        }
      )
    
  }else if(this.code.length==0){
    this.GetProduct();
    this.toastr.warning("لا يوجد منتج بهذا الكود")
  }
  
 }

 OpenQrRead(){
  this.dialog.open(ReadQrComponent);

 }

 SearchByIqCode(){
  this.paginationInfo.pageSize=10;
  if(isNumber(this.iqCode)){
    let product:Product = {
      productIqCode:this.iqCode
    }
      this.productService.Search(product).subscribe(
      data=>
      {
        if(data==null)
          this.toastr.warning("لا يوجد منتج بهذا الكود")
        this.dialog.open(ShowProductDialogComponent,{data:data[0],width:"100%"})
        this.productDto=data
      }
    )
  
}else if(this.code.length==0){
  this.GetProduct();
  this.toastr.warning("لا يوجد منتج بهذا الكود")
}

 }
 

}

function isNumber(value: string | number): boolean
{
   return ((value != null) &&
           (value !== '') &&
           !isNaN(Number(value.toString())));
}




