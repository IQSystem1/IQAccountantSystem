import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth-module/login/login.component';
import { AuthGuard } from './Guards/auth.guard';
import { PrintBarcodeComponent } from './print-barcode/print-barcode.component';
import { PrintQrCodeComponent } from './print-qr-code/print-qr-code.component';
import { SearchProductComponent } from './sales/search-product/search-product.component';
import { ShowProductComponent } from './show-product/show-product.component';
import { VideoPageComponent } from './video-page/video-page.component';

const routes: Routes = [
  {path:"",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule),canActivate:[AuthGuard]},
  {path:"products",component:ShowProductComponent,canActivate:[AuthGuard]},
  {path:"sale",component:SearchProductComponent,canActivate:[AuthGuard]},
  {path:"video/:iqCode",component:VideoPageComponent,canActivate:[AuthGuard]},
  {path:"barcode/:iqCode",component:PrintBarcodeComponent,canActivate:[AuthGuard]},
  {path:"qrcode/:iqCode",component:PrintQrCodeComponent,canActivate:[AuthGuard]},
  {path:"log",component:LoginComponent},
  {path:"**",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
