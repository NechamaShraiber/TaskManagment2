import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { of, Subject, Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class WorkerService {
worker:Worker;
subStr:string="";
bodyStr:string="";
subjectUpdateChart=new Subject();
  constructor(private http: HttpClient, private router: Router) {
    this.worker=null;
 }

login(userName: string, password: string): Observable<any> {
  let data = { userName: userName, password: password };
  return this.http.post("http://localhost:59628/api/login/", data);
}
 getProject(id:number):any{
   return this.http.get("http://localhost:59628/api/getProject/"+id)
 }

sendMsg():any {
  let data = { body: this.bodyStr, sub: this.subStr };
  return this.http.post("http://localhost:59628/api/sendMsg", data)
}
updateStartHour(time:number, id:number, isFirst:boolean):any {
  let data = { hour:time , idProjectWorker:id,isFirst:isFirst };
  return this.http.post("http://localhost:59628/api/updateStartHour", data)
}
// getProject( id:number):any {
//   return this.http.get("http://localhost:59628/api/getProject/"+id)
// }

}