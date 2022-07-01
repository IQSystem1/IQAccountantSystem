import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { SalesTableHeaderComponent } from './sales-table-header/sales-table-header.component';
import { SalesTableComponent } from './sales-table/sales-table.component';
import { SalesAllBillComponent } from './sales-all-bill/sales-all-bill.component';
import { SalesMainComponent } from './sales-main/sales-main.component';
import {MatDialogModule} from '@angular/material/dialog';
import { AddProductComponent } from './add-product/add-product.component';
import { ButtonOperationsComponent } from './button-operations/button-operations.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchProductComponent } from './search-product/search-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { DeleteProductComponent } from './delete-product/delete-product.component';
import { AddProductWithCodeComponent } from './add-product-with-code/add-product-with-code.component';

@NgModule({
  declarations: [
    SalesTableHeaderComponent,
    SalesTableComponent,
    SalesAllBillComponent,
    SalesMainComponent,
    AddProductComponent,
    ButtonOperationsComponent,
    SearchProductComponent,
    EditProductComponent,
    DeleteProductComponent,
    AddProductWithCodeComponent,
    
  ],
  imports: [
    CommonModule,
    SalesRoutingModule,
    MatDialogModule,
    ReactiveFormsModule,
    FormsModule,
    

  ]
})
export class SalesModule { }