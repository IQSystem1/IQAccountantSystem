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
import { FormsModule } from '@angular/forms';
import * as $ from "jquery";
import { NgxSpinnerModule } from "ngx-spinner";

import { ToastrModule } from 'ngx-toastr';
import { ShowProductComponent } from './show-product/show-product.component';
import { PrintPdfComponent } from './print-pdf/print-pdf.component';
import { PrintNoteComponent } from './print-note/print-note.component';
import { ShowVideosComponent } from './show-videos/show-videos.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeaderComponent,
    HeaderNavbarComponent,
    HeaderTitleComponent,
    ShowProductComponent,
    PrintPdfComponent,
    PrintNoteComponent,
    ShowVideosComponent
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
    MDBBootstrapModule.forRoot()


  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
