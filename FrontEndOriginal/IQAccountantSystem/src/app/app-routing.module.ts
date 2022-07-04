import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrintBarcodeComponent } from './print-barcode/print-barcode.component';
import { PrintQrCodeComponent } from './print-qr-code/print-qr-code.component';
import { SearchProductComponent } from './sales/search-product/search-product.component';
import { ShowProductComponent } from './show-product/show-product.component';
import { VideoPageComponent } from './video-page/video-page.component';

const routes: Routes = [
  {path:"",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)},
  {path:"products",component:ShowProductComponent},
  {path:"sale",component:SearchProductComponent},
  {path:"video/:iqCode",component:VideoPageComponent},
  {path:"barcode/:iqCode",component:PrintBarcodeComponent},
  {path:"qrcode/:iqCode",component:PrintQrCodeComponent},
  {path:"**",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)},



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
