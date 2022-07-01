import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BarcodeGeneratorDemoComponent } from './barcode-generator-demo/barcode-generator-demo.component';
import { PrintNoteComponent } from './print-note/print-note.component';
import { PrintPdfComponent } from './print-pdf/print-pdf.component';
import { SalesModule } from './sales/sales.module';
import { SearchProductComponent } from './sales/search-product/search-product.component';
import { ShowProductComponent } from './show-product/show-product.component';

const routes: Routes = [
  {path:"",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)},
  {path:"products",component:ShowProductComponent},
  {path:"print/:id",component:PrintPdfComponent},
  {path:"printNote/:id",component:PrintNoteComponent},

  {path:"sale",component:SearchProductComponent},
  {path:"**",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
