import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { AddProductComponent } from '../add-product/add-product.component';
import { SearchProductComponent } from '../search-product/search-product.component';

@Component({
  selector: 'app-sales-main',
  templateUrl: './sales-main.component.html',
  styleUrls: ['./sales-main.component.css']
})
export class SalesMainComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(SearchProductComponent, {
      width: '50%',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}
