import { HtmlParser } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AddProductComponent } from '../add-product/add-product.component';
import { SearchProductComponent } from '../search-product/search-product.component';

@Component({
  selector: 'app-button-operations',
  templateUrl: './button-operations.component.html',
  styleUrls: ['./button-operations.component.css']
})
export class ButtonOperationsComponent implements OnInit {

  constructor(public dialog: MatDialog) {}
  
  ngOnInit(): void {
    
    this.toggleHide();
  }
  OpenAddProduct(){
    const dialogRef = this.dialog.open(AddProductComponent, {
      width: '500px', height:"1000px"
    });
  }
  toggleHide(){
    var hides = $(".operation") ; 
    
    for(var i=0;i<hides.length;i++){
      hides[i].onmouseenter=function(){
        var hide = this as HTMLElement;
        hide.classList.remove("hide")
      }
      hides[i].onmouseleave=function(){
        var hide = this as HTMLElement;
        hide.classList.add("hide")
      }
    }
  }
  OpenSale(){
    this.dialog.open(SearchProductComponent,{width:"1000px",height:"500px"})
  }


  
}
