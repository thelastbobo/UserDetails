import { Component, OnInit } from '@angular/core';
import { DataService } from './shared/dataService';
import { User } from './user';
import { SubmitService } from './shared/submit.service';

@Component({
  selector: 'app-root',
  templateUrl: "./app.component.html",
  styleUrls: ['./app.component.css']
})
export class AppComponent {
     

  errorMsg = '';

  constructor(private _submitService: SubmitService,
              private _dataService: DataService) { }

  public user = [];
  userModel = new User(1, 'Bogdan', 'Manole', 'bogdan', new Date('6/15/15'));

  onSubmit() {
    this._submitService.submit(this.userModel)
      .subscribe(
        data => console.log('Success', data),
        error => this.errorMsg = error.error.errors.Username
        );
  }
}
