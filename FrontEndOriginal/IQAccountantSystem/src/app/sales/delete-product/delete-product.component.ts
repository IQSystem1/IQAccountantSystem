import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';


import { ProductService } from 'src/app/Services/product.service';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {

  constructor(private productService:ProductService, private spinner:NgxSpinnerService,private route: ActivatedRoute, private toastr:ToastrService,   
    private router:Router,@Inject(MAT_DIALOG_DATA) public productDto:ProductDTO,public dialog: MatDialog) { }

  ngOnInit(): void {
    
  }
  Submit(){
    
    this.productService.Delete(Number(this.productDto.productId)).subscribe(
      data=>{
        if(data.isSuccess){
          this.toastr.success("Deleted Successfully");
          this.router.navigate(['../../products']);
        }
        else{
          this.toastr.error(data.message);
        }
        this.dialog.closeAll();
      },error=>{
        this.toastr.error(error.message);
        this.dialog.closeAll();
      }
    )
  }

  


}


