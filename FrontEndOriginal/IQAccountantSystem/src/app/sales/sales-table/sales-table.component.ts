import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PaginationInfo } from 'src/app/Models/PaginationInfo';
import { SaleDTO } from 'src/app/Models/SaleDTO';
import { SaleService } from 'src/app/Services/sale.service';
import { ShowVideosComponent } from 'src/app/show-videos/show-videos.component';


@Component({
  selector: 'app-sales-table',
  templateUrl: './sales-table.component.html',
  styleUrls: ['./sales-table.component.css']
})
export class SalesTableComponent implements OnInit {

  code :string="";
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
        console.log(this.sales)
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
          this.sales=data
        }
      )
    
  }else if(this.code.length==0){
    this.GetSales();
  }
  
  }

  PaginateLess(){
    this.paginationInfo.pageSize-=10;
    this.GetSales();
  }


  OpenVideosDialog(sale:SaleDTO){
    this.dialog.open(ShowVideosComponent,{data:sale,width:"100%"})
  }
  
}
function isNumber(value: string | number): boolean
{
   return ((value != null) &&
           (value !== '') &&
           !isNaN(Number(value.toString())));
}

