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
 OpenDeleteComponent(productId:number){
  this.dialog.open(DeleteProductComponent);
  DeleteProductComponent
 }
 Print(){
  window.print();
 }

}




