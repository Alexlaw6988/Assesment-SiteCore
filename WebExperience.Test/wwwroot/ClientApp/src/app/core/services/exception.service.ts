import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ExceptionService {

  constructor( private toastr: ToastrService) { }

  displayError(message: string){
    this.toastr.error(message);
  }

  displaySuccess(message: string){
    this.toastr.success(message);
  }

  displayWarning(message: string){
    this.toastr.warning(message);
  }

}
