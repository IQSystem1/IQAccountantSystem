import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AddProductComponent } from '../add-product/add-product.component';

@Component({
  selector: 'app-button-operations',
  templateUrl: './button-operations.component.html',
  styleUrls: ['./button-operations.component.css']
})
export class ButtonOperationsComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    
  }
  OpenAddProduct(){
    const dialogRef = this.dialog.open(AddProductComponent, {
      width: '500px',
    });
  }

  
}
