import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductWithCodeComponent } from './add-product-with-code/add-product-with-code.component';
import { DeleteProductComponent } from './delete-product/delete-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { SalesMainComponent } from './sales-main/sales-main.component';

const routes: Routes = [
  {path:"",component:SalesMainComponent},
  {path:"edit/:id",component:EditProductComponent},
  {path:"delete/:id",component:DeleteProductComponent},
  {path:"add/:id",component:AddProductWithCodeComponent},


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesRoutingModule { }
