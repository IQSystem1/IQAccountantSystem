import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';


import { ProductService } from 'src/app/Services/product.service';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FileService } from 'src/app/Services/file.service';


@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {

  private sub: any;
  productCode:number = 0;
  selectedVideo:any;
  selectedImage:any;

  

  constructor(private productService:ProductService, private spinner:NgxSpinnerService,private route: ActivatedRoute, private toastr:ToastrService,
    private fileService:FileService,private router:Router) { }

  
   product:ProductDTO ={
    productName: '',
    productCode: '',
    productUnit: '',
    productPrice: 0
  }

  ngOnInit(): void {
    this.spinner.show();

    this.sub = this.route.params.subscribe(params => {
      this.productCode = +params['id'];
      this.productService.GetById(this.productCode).subscribe(
        data=>{
          if(data){
            this.product = data;
          }
          else{
          this.router.navigate(['../../products']);
          }
          this.spinner.hide();
        },error=>this.toastr.error(error.message)
      )
    });
  }

  Submit(){
         
    this.productService.Delete(Number(this.product.productId)).subscribe(
      data=>{
        if(data.isSuccess){
          this.toastr.success("Deleted Successfully");
          this.router.navigate(['../../products']);
        }
        
        
      },error=>{
        this.toastr.error(error.message);
      }
    )
  }

  


}


