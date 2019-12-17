import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { User } from '../user';
import { catchError, retry } from 'rxjs/operators'
import { throwError } from 'rxjs'

@Injectable()
export class SubmitService {

  _url = '/user'
  constructor(private _http: HttpClient) { }

  submit(user: User) {
    return this._http.post<any>(this._url, user)
      .pipe(catchError(this.errorHandler))
  }

  errorHandler(error: HttpErrorResponse) {
    return throwError(error);
  }
}
