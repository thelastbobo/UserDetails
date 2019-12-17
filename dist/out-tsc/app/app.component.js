import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { User } from './user';
let AppComponent = class AppComponent {
    constructor(_submitService, _dataService) {
        this._submitService = _submitService;
        this._dataService = _dataService;
        this.errorMsg = '';
        this.user = [];
        this.userModel = new User(1, 'Bogdan', 'Manole', 'bogdan', new Date('6/15/15'));
    }
    onSubmit() {
        this._submitService.submit(this.userModel)
            .subscribe(data => console.log('Success', data), error => this.errorMsg = error.error.errors.Username);
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: "./app.component.html",
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map