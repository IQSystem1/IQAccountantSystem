import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BarcodeService } from '../Services/barcode.service';

@Component({
  selector: 'barcode-generator-demo',
  templateUrl: './barcode-generator-demo.component.html'
})
export class BarcodeGeneratorDemoComponent {

  isImageLoading=false;
  constructor(private barcodeService:BarcodeService){}
  image:any;
  ngOnInit() {
    this.barcodeService.GetBarCode().subscribe(
      data => {
        this.createImageFromBlob(data);
        this.isImageLoading = false;
      }, error => {
        this.isImageLoading = false;
        console.log(error);
      });
    
    
  }
  imageToShow: any;

createImageFromBlob(image: Blob) {
   let reader = new FileReader();
   reader.addEventListener("load", () => {
      this.imageToShow = reader.result;
   }, false);

   if (image) {
      reader.readAsDataURL(image);
   }
}

  

}