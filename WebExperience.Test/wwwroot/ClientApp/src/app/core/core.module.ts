import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { GlobalHttpInterceptorService } from './interceptors';
import { AssetService } from './services/api';
import { ExceptionService } from './services/exception.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptorService, multi: true}   ,
    AssetService,
    ExceptionService
  ],
  declarations: []
})
export class CoreModule { }
