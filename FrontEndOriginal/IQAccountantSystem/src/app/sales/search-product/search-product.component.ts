import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ProductDTO } from 'src/app/Models/ProductDTO';
import { SaleProductDTO } from 'src/app/Models/SaleProductDTO';
import { ProductService } from 'src/app/Services/product.service';
import { SaleService } from 'src/app/Services/sale.service';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit {

  productToSale = new Map<string,number>();
  bindedProductToSaleKeys :any;
  product:ProductDTO={
    barcodeImage: null
  }
  isProduct = true;
  
  products:ProductDTO[]=[]
  constructor(private productService:ProductService, private toastr:ToastrService, private saleService:SaleService,private dialog:MatDialog) { }

  ngOnInit(): void {
  }
  GetProduct(){
    this.productService.Search(this.product).subscribe(
      data=>{
        if(data.length==0 && this.product.productCode){
          this.isProduct = false;
        }else{
          this.isProduct = true;  
        }
        this.products = data;

        
      }
    )

  }

    GetProductByDoubleClick(product:ProductDTO){
    this.product = product;
    if(this.product.productIqCode)
    {
      if(this.productToSale.has(this.product.productIqCode)){
          this.productToSale.set(this.product.productIqCode, Number(this.productToSale.get(this.product.productIqCode))+1)
        
      }else{
        this.productToSale.set(this.product.productIqCode,1);
      }
      this.bindedProductToSaleKeys = this.productToSale.keys();
    }
  }

  DeleteProductToSale(productKey:string){
    this.productToSale.delete(productKey);
  }

  AddOneProductToSale(productKey:string){
    this.productToSale.set(productKey, Number(this.productToSale.get(productKey))+1)
  }

  MinusOneProductToSale(productKey:string){
    this.productToSale.set(productKey, Number(this.productToSale.get(productKey))-1)
    if(this.productToSale.get(productKey)==0){
      this.productToSale.delete(productKey);
    }
  }

  AddquantityProduct(productKey:string,quantity:any){
    this.productToSale.set(productKey,Number(quantity.value))
    
  }

  Submit(){
    if(this.productToSale.values().next().value){
      this.productToSale.forEach((value , key )=> {
        let saleProduct:SaleProductDTO = {
          productIqCode : key,
          quantity:value,
        }
        this.InsertSale(saleProduct);
        this.dialog.closeAll();
        window.location.reload();
      });
      

    }else{
      this.toastr.warning("لا يوجد منتجات للبيع")

    }
  }
  InsertSale(saleProduct: SaleProductDTO) {
    this.saleService.post(saleProduct).subscribe(
      data=>{
        if(data!=null)
          this.toastr.success("Inserted")
      },error=>{
        this.toastr.error(error.message)
      }
    )
  }
  ChangeProductCode(){
    this.product.productIqCode = "";
    this.product.productName = "";
  }
  ChangeProductIqCode(){
    this.product.productCode = "";
    this.product.productName = "";
  }
  ChangeProductName(){
    this.product.productCode = "";
    this.product.productIqCode = "";
  }
  
}
