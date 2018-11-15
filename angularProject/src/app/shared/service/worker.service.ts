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
idJob:number;
projectStart:any=null;

  constructor(private http: HttpClient, private router: Router) {
    this.worker=null;
 }


 getProject(id:number):any{
   return this.http.get("http://localhost:59628/api/getProject/"+id)
 }

sendMsg():any {
  let data = { body: this.bodyStr, sub: this.subStr ,id:JSON.parse(localStorage.getItem('currentUser')).ManagerId};
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