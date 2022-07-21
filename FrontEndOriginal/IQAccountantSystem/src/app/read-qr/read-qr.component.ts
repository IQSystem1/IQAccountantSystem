import {  Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ShowProductDialogComponent } from '../sales/show-product-dialog/show-product-dialog.component';
import { SaleService } from '../Services/sale.service';
@Component({
  selector: 'app-read-qr',
  templateUrl: './read-qr.component.html',
  styleUrls: ['./read-qr.component.css']
})
export class ReadQrComponent implements OnInit {


  constructor(private saleService:SaleService, private dialog:MatDialog,private toastr:ToastrService) {
  }

  ngOnInit() {
  }

  result:any;
  OnCodeResult(result:string)
  {
    console.log(result)
    this.saleService.SearchByCode(String(result)).subscribe(
      data=>
      {
        if(data==null){
          
          this.toastr.warning(String(data) +" لا يوجد منتج بهذا الكود")
          this.dialog.closeAll();
        }else{
          console.log(data)
          this.dialog.closeAll();
          this.dialog.open(ShowProductDialogComponent,{data:data[0],width:"100%"})
        }
        
      });
  }

}

