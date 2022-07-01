import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from 'src/app/Services/product.service';
import { FileService } from 'src/app/Services/file.service';
import { NgxSpinnerService } from "ngx-spinner";
import { MatDialog } from '@angular/material/dialog';
import { ProductDTO } from 'src/app/Models/ProductDTO';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
   @Input() product:ProductDTO={
    productName: '',
    productCode: '',
    productUnit: '',
    productPrice: 0
  } ;
  

  selectedImage:any;
  selectedVideo:any;



  productForm =new FormGroup({
    productCode:new FormControl(this.product.productCode,[Validators.required]),
    productName:new FormControl(null,[Validators.required]),
    productUnit: new FormControl(null,[Validators.required]),
    productPrice: new FormControl(null,[Validators.required]),
    productTax: new FormControl(null),
    productNote: new FormControl(null),
    productImage: new FormControl(null),
    productVideo: new FormControl(null)
  })


  constructor(private productService:ProductService,
    private fileService:FileService,
    private toastr:ToastrService,
    private spinner:NgxSpinnerService,
    public dialog: MatDialog) { }

  
  ngOnInit(): void {
    console.log(this.product.productCode)
  }
  Submit(){
    
    if(this.productForm.valid){
      this.FillProduct();
      if(this.selectedImage || this.selectedVideo){
        this.product.productIqCode = "yes";
      }
      this.spinner.show();
        this.UploadFile();
        this.FillProduct();
    }else{
      this.toastr.error("رجاء قم بتعبئة المعلومات بشكل صحيح")
    }
  }



  FillProduct(){
    if(this.productForm.controls["productCode"].value)
      this.product.productCode = this.productForm.controls["productCode"].value;
    if(this.productForm.controls["productName"].value)
      this.product.productName = this.productForm.controls["productName"].value;
    if(this.productForm.controls["productUnit"].value)
      this.product.productUnit = this.productForm.controls["productUnit"].value;
    if(this.productForm.controls["productTax"].value)
      this.product.productTax = this.productForm.controls["productTax"].value;
    if(this.productForm.controls["productPrice"].value)
      this.product.productPrice = this.productForm.controls["productPrice"].value;
    if(this.productForm.controls["productNote"].value)
      this.product.productNote = this.productForm.controls["productNote"].value;
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

  InsertProduct(){
    this.productService.Post(this.product).subscribe(
      data=>{
        this.spinner.hide();
        this.toastr.success("تم الحفظ");
        this.dialog.closeAll();
      },error=>{
        this.toastr.error(error.message);
        this.spinner.hide();
      }
    );    
  }
 
  UploadFile(){
    if(this.selectedImage){
      this.fileService.Upload(this.selectedImage).subscribe(
        data=>{

          this.product.imageUrl = data.message;
          if(this.selectedVideo){
            this.fileService.Upload(this.selectedVideo).subscribe(
              data=>{
                this.product.videoUrl = data.message;
                this.InsertProduct();
              },error=>{
                this.spinner.hide();
                this.toastr.error(error.message)      
              }
            )
          }else{
            this.InsertProduct();
          }
        },error=>{
          this.spinner.hide();
          this.toastr.error(error.message)
        }
      )
    }else if(this.selectedVideo){
      this.fileService.Upload(this.selectedVideo).subscribe(
        data=>{
          this.product.videoUrl = data.message;
          this.InsertProduct();
        },error=>{
          this.spinner.hide();
          this.toastr.error(error.message)      
        }
      )
    }
    else{
      this.InsertProduct();
    }
    
  }

  FlagVideo(){
    if(!this.selectedVideo){
      this.spinner.hide();
      this.dialog.closeAll();
    }

  }
  FlagImage(){
      this.spinner.hide();
      this.dialog.closeAll();
    
  }
  
}
