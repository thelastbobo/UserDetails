import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
let SubmitService = class SubmitService {
    constructor(_http) {
        this._http = _http;
        this._url = '/user';
    }
    submit(user) {
        return this._http.post(this._url, user)
            .pipe(catchError(this.errorHandler));
    }
    errorHandler(error) {
        return throwError(error);
    }
};
SubmitService = __decorate([
    Injectable()
], SubmitService);
export { SubmitService };
//# sourceMappingURL=submit.service.js.map