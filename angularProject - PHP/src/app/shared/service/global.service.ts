import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, } from 'rxjs';
import { Router } from '../../../../node_modules/@angular/router';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
static path:string="http://localhost:59628/api/"
URLPHPUSERS: string = "http://localhost/TaskManagment/UIL/index.php"
  constructor( private http: HttpClient,private router: Router) { }
  login(userName: string, password: string): Observable<any> {
    let data = { userName: userName, password: password };
    return this.http.post(GlobalService.path+"login", data);
  }
  logOut(){
    localStorage.removeItem('currentUser');
    this.router.navigate(['taskManagers/login']);
  }
  getAllJobs(): any {
   // return this.http.get(GlobalService.path+"getAllJobs");
    return this.http.get(this.URLPHPUSERS+"?funcation=getAllJobs");
  }
  updatePassword(userName:string,oldpassword:string,newPassord:string): Observable<any> {
    let data = { userName: userName, oldpassword: oldpassword,newPassord:newPassord };
    return this.http.post(GlobalService.path+"updatePassword", data);
  }
}

