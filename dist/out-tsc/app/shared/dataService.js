import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
let DataService = class DataService {
    constructor(_http) {
        this._http = _http;
        this.user = [];
    }
    loadUser() {
        return this._http.get("/user?id=1")
            .pipe(map((data) => {
            this.user = data;
            return true;
        }));
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map