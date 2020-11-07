import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { finalize, catchError} from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {
  spinnerName: string;
  constructor(private spinner: NgxSpinnerService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.spinnerName = 'primary';
    this.spinner.show(this.spinnerName);
    
    return next.handle(req).pipe(
      catchError(
        (error: any) => {
          return throwError(error);
        }
      ),
      finalize(() => {
        this.spinner.hide(this.spinnerName);
      })
    );
  }

  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        'Authorization': `Bearer ${token}`
      }
    });
  }
}
