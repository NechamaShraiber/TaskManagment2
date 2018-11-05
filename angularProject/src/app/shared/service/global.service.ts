import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  constructor( private http: HttpClient) { }
  login(userName: string, password: string): Observable<any> {
    let data = { userName: userName, password: password };
    return this.http.post("http://localhost:59628/api/login", data);
  }
  getAllJobs(): any {
    return this.http.get("http://localhost:59628/api/getAllJobs");
  }
}
