import { HttpClient } from '@angular/common/http';
import {Injectable} from "@angular/core"
import { map } from "rxjs/operators"
@Injectable()
export class DataService {

  constructor(private _http: HttpClient) { }

  public user = [];

  loadUser() {
    return this._http.get("/user?id=1")
      .pipe(
        map((data: any[]) => {
          this.user = data;
          return true;
        }))
  }
}