import {Injectable} from "@angular/core";
import {HttpEvent, HttpHandler, HttpInterceptor,HttpRequest} from '@angular/common/http';
import {Observable} from "rxjs";
import {catchError} from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ExceptionService } from "../services";

@Injectable()
export class GlobalHttpInterceptorService implements HttpInterceptor {
    
  constructor(private exceptionService: ExceptionService ) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): 
        Observable<HttpEvent<any>> {
          return next.handle(req).pipe(
             catchError( (error) => {   
              this.exceptionService.displayError("Some error occured. Please try after some time, If issue persist please contact Admin");
                return throwError(error);              
          })
        );
    }  
}
