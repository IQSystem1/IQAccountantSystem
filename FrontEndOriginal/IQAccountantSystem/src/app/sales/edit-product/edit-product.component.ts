import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { FileService } from 'src/app/Services/file.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  private sub: any;
  productCode:number = 0;
  selectedVideo:any;
  selectedImage:any;

  

  constructor(private productService:ProductService, private spinner:NgxSpinnerService,private route: ActivatedRoute, private toastr:ToastrService,
    private fileService:FileService) { }

  
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
          this.product = data;
          this.spinner.hide();
        },error=>this.toastr.error(error.message)
      )
    });
  }


  Submit(){
    this.spinner.show();
    if(this.selectedImage){
      this.UploadImage();
    }else{
      this.UploadVideo();
    }
            
    
  }

  Update(){
    console.log(this.product)
    this.productService.Put(this.product).subscribe(
      data=>{
        this.spinner.hide();
        this.toastr.success("تم التعديل");
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.message);
      }
    )
  }

  UploadImage(){
    if(this.selectedImage){
      this.fileService.Upload(this.selectedImage).subscribe(
        data=>{
          this.product.imageUrl = data.message;
          if(this.selectedVideo){
            this.UploadVideo();
          }else{
            this.product.videoUrl = "";
            this.Update();
          }
        },error=>{
          this.spinner.hide();
          this.toastr.error(error.message);
        }
      )
    }
    
  }
  UploadVideo(){
    if(this.selectedVideo){
    this.fileService.Upload(this.selectedVideo).subscribe(
      data=>{
        this.product.videoUrl = data.message;
        if(!this.selectedImage){
          this.product.imageUrl= "";
        }
        this.Update();
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.message)
      }
    )
    }else{
      this.Update();
    }
  }



 



  ImageOperation(event:Event){
    var target = event.target as HTMLInputElement;
    if(target.files?.length){
      var src = URL.createObjectURL(target.files[0]);
      if(target.files.item(0)){
        var src = URL.createObjectURL(target.files[0]);
        this.selectedImage = target.files.item(0);
        var prev = document.getElementById("img") as HTMLImageElement;
        prev.src=src;
        $("#newImg").removeClass("d-none")
        
      }
    }
  }

  VideoOperation(event:Event){
    var target = event.target as HTMLInputElement;
    if(target.files?.length){
      var src = URL.createObjectURL(target.files[0]);
      if(target.files.item(0)){
        var src = URL.createObjectURL(target.files[0]);
        this.selectedVideo = target.files.item(0);
        var prev = document.getElementById("video") as HTMLImageElement;
        prev.src=src;
        $("#newVideo").removeClass("d-none")
        
      }
    }
  }
  flagVideo(){
    if(!this.selectedVideo)
      this.spinner.hide();
  }

}
