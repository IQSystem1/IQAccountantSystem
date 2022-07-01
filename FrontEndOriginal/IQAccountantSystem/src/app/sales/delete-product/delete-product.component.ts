import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';


import { ProductService } from 'src/app/Services/product.service';
import { ProductDTO } from 'src/app/Models/ProductDTO';


@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {

  flagImage = false;
  flagVideo = false;
  constructor(private productService:ProductService, private spinner:NgxSpinnerService,private route: ActivatedRoute, private toastr:ToastrService,
    
    private router:Router) { }


  productDto:ProductDTO = {
    
  }
  
  private sub: any;
  productId = 0;
  ngOnInit(): void {
    this.spinner.show();

    this.sub = this.route.params.subscribe(params => {
      this.productId = +params['id'];
      this.productService.GetById(this.productId).subscribe(
        data=>{
          this.productDto = data;
          this.spinner.hide();
          console.log(this.productDto)
        },error=>{
          this.spinner.hide();
          this.toastr.error(error.message)
        }

      )
    });
  }
  Submit(){
    
    this.productService.Delete(Number(this.productId)).subscribe(
      data=>{
        if(data.isSuccess){
          this.toastr.success("Deleted Successfully");
          this.router.navigate(['../../products']);
        }
        else{
          this.toastr.error(data.message);
        }
      },error=>{
        this.toastr.error(error.message);
      }
    )
  }

  


}


