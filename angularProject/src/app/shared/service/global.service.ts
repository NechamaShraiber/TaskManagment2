import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
static path:string="http://localhost:59628/api/"
  constructor( private http: HttpClient) { }
  login(userName: string, password: string): Observable<any> {
    let data = { userName: userName, password: password };
    return this.http.post(GlobalService.path+"login", data);
  }
  getAllJobs(): any {
    return this.http.get(GlobalService.path+"getAllJobs");
  }
}
