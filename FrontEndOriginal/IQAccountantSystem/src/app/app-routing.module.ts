import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchProductComponent } from './sales/search-product/search-product.component';
import { ShowProductComponent } from './show-product/show-product.component';
import { VideoPageComponent } from './video-page/video-page.component';

const routes: Routes = [
  {path:"",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)},
  {path:"products",component:ShowProductComponent},
  {path:"sale",component:SearchProductComponent},
  {path:"video/:url",component:VideoPageComponent},
  {path:"**",loadChildren:()=> import('./sales/sales.module').then(m=>m.SalesModule)}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
