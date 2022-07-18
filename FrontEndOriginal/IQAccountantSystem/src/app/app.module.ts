import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HeaderComponent } from './header/header.component';
import { HeaderNavbarComponent } from './header/header-navbar/header-navbar.component';
import { HeaderTitleComponent } from './header/header-title/header-title.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import * as $ from "jquery";
import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from 'ngx-toastr';
import { ShowProductComponent } from './show-product/show-product.component';
import { PrintNoteComponent } from './print-note/print-note.component';
import { ShowVideosComponent } from './show-videos/show-videos.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { SalesMainComponent } from './sales/sales-main/sales-main.component';
import { VideoPageComponent } from './video-page/video-page.component';
import { PrintQrCodeComponent } from './print-qr-code/print-qr-code.component';
import { PrintBarcodeComponent } from './print-barcode/print-barcode.component';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { ReadQrComponent } from './read-qr/read-qr.component';
import { AuthModuleModule } from './auth-module/auth-module.module';
import { AuthGuard } from './Guards/auth.guard';
import { UserService } from './Services/user.service';
import { TokenInterceptorService } from './Services/token-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeaderComponent,
    HeaderNavbarComponent,
    HeaderTitleComponent,
    ShowProductComponent,
    PrintNoteComponent,
    ShowVideosComponent,
    VideoPageComponent,
    PrintQrCodeComponent,
    PrintBarcodeComponent,
    ReadQrComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    MatDialogModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot() ,
    NgxSpinnerModule,
    MDBBootstrapModule.forRoot(),
    ZXingScannerModule,
    ReactiveFormsModule,
    AuthModuleModule

  ],
  providers: [UserService,
    AuthGuard,{
      provide:HTTP_INTERCEPTORS,
      useClass:TokenInterceptorService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
