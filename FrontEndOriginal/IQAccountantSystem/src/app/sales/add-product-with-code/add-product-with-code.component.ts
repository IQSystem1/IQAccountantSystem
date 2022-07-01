import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ProductDTO } from 'src/app/Models/ProductDTO';

@Component({
  selector: 'app-add-product-with-code',
  templateUrl: './add-product-with-code.component.html',
  styleUrls: ['./add-product-with-code.component.css']
})
export class AddProductWithCodeComponent implements OnInit {

  productDto : ProductDTO = {};


  sub:any;
  constructor(private productService:ProductService,
    private route: ActivatedRoute,
    public dialog: MatDialog) { }

  
  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.productDto.productCode = params['id'];
    })
  }


}
