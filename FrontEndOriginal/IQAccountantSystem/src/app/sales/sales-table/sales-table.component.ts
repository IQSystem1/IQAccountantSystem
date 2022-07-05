import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { PaginationInfo } from 'src/app/Models/PaginationInfo';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { SaleDTO } from 'src/app/Models/SaleDTO';
import { PrintBarcodeComponent } from 'src/app/print-barcode/print-barcode.component';
import { SaleService } from 'src/app/Services/sale.service';
import { ShowVideosComponent } from 'src/app/show-videos/show-videos.component';
import { EditProductComponent } from '../edit-product/edit-product.component';
import { ShowProductDialogComponent } from '../show-product-dialog/show-product-dialog.component';


@Component({
  selector: 'app-sales-table',
  templateUrl: './sales-table.component.html',
  styleUrls: ['./sales-table.component.css']
})
export class SalesTableComponent implements OnInit {

  code :string="";
  iqCode:string="";
  paginationInfo:PaginationInfo ={
    pageNo:1,
    pageSize:10
  };
  sales:SaleDTO[] = []
  count = 0;
  constructor(private saleService:SaleService, private toastr:ToastrService, private dialog:MatDialog) { }
  

  ngOnInit(): void {
    this.GetSales();
    this.GetSalesCount();
  }
  GetSalesCount() {
    this.saleService.getCount().subscribe(
      data=>this.count = data.count
    )
  }
  Paginate(){
    this.paginationInfo.pageSize+=10
    this.GetSales();
  }
  GetSales(){
    this.saleService.get(this.paginationInfo).subscribe(
      data=>{
        this.sales = data;
      },error=>{
        console.log(error);
      }
    )
  }
  Search(){
    this.paginationInfo.pageSize=10;
    if(isNumber(this.code)){
        this.saleService.SearchByCode(String(this.code)).subscribe(
        data=>
        {
          if(data==null)
            this.toastr.warning("لا يوجد منتج بهذا الكود")
          this.dialog.open(ShowProductDialogComponent,{data:data[0],width:"100%"})
          this.sales=data
        }
      )
    
  }else if(this.code.length==0){
    this.GetSales();
  }
  
  }

  SearchByIqCode(){
    this.paginationInfo.pageSize=10;
    if(isNumber(this.iqCode)){
        this.saleService.SearchByIqCode(String(this.iqCode)).subscribe(
        data=>
        {
          if(data==null)
            this.toastr.warning("لا يوجد منتج بهذا الكود")
          else
          {

            let product:ProductDTO = ConvertSaleDTOToProductDTO(data[0]);
            product.productCode = "";
            this.dialog.open(ShowProductDialogComponent,{data:product,width:"100%"})
          }
            this.sales=data
        }
      )
    
  }else if(this.iqCode.length==0){
    this.GetSales();
  } 
  }

  PaginateLess(){
    this.paginationInfo.pageSize-=10;
    this.GetSales();
  }
  WatchVideo(productIqCode?:string){
    window.open("video/"+productIqCode, "_blank", "height=500,width=1000");
  }

  OpenPrintBarcode(sale:SaleDTO){
    let product:ProductDTO = {
      productIqCode : sale.productIqCode,
      productNote:sale.productNote,
      productName:sale.productName
    }
    this.dialog.open(PrintBarcodeComponent,{data:product,width:"100%"})
  }

  OpenEditProduct(sale:SaleDTO){
    let product =ConvertSaleDTOToProductDTO(sale);
    this.dialog.open(EditProductComponent,{data:product,width:"100%"})
  }

  
  
}
function isNumber(value: string | number): boolean
{
   return ((value != null) &&
           (value !== '') &&
           !isNaN(Number(value.toString())));
}


function ConvertSaleDTOToProductDTO(sale:SaleDTO):ProductDTO{
  let product:ProductDTO = {
    productCode : sale.productCode,
    productId:sale.productId,
    productIqCode:sale.productIqCode,
    productName:sale.productName,
    productNote:sale.productNote,
    productTax:sale.productTax,
    productPrice:sale.productPrice,
    productUnit:sale.productUnit,
    videoUrl:sale.videoUrl,
    imageUrl:sale.imageUrl
  }
  return product;
}


function ConvertSaleDTOsToProductDTOs(sales:SaleDTO[]):ProductDTO[]{
  let products:ProductDTO[] = []
  sales.forEach((sale)=>{
    products.push(ConvertSaleDTOToProductDTO(sale))
  }
  )
  return products;
}