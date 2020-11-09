import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { timeout } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable()
export class EmployeeService {

  constructor(private _http: HttpClient) { }

  public listEmployees() {
    const header = this.setHeader();
    return this._http.get(environment.url +  environment.services.list,  { headers: header } ).pipe(
      timeout(environment.timeOut)
    ).toPromise();
  }

  public getemployee(id: number){
    const header = this.setHeader();
    return this._http.get(environment.url +  environment.services.get + id, { headers: header } ).pipe(
      timeout(environment.timeOut)
    ).toPromise();
  }

  public setHeader(): any {
    return new Headers({
      'Access-Control-Allow-Origin':'*',
      'Content-Type': 'application/json'
    });
  }

}
