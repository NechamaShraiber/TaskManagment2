import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import {  Subject  } from 'rxjs';
import { Router  } from '@angular/router';
import { GlobalService } from './global.service';
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
   return this.http.get(GlobalService.path+"getProject/"+id)
 }

sendMsg():any {
  let data = { body: this.bodyStr, sub: this.subStr ,id:JSON.parse(localStorage.getItem('currentUser')).ManagerId};
  return this.http.post(GlobalService.path+"sendMsg", data)
}
updateStartHour(time:number, id:number, isFirst:boolean):any {
  let data = { hour:time , idProjectWorker:id,isFirst:isFirst };
  return this.http.post(GlobalService.path+"updateStartHour", data)
}
}