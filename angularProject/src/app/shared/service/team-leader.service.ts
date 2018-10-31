import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import{AppModule}from './../../app.module'
@Injectable({
  providedIn: 'root'
})
export class TeamLeaderService {

  constructor(private http: HttpClient) { }
  getAllProjects(id:number): any {
    return this.http.get("http://localhost:59628/api/getProjectDeatails/"+id);
  }
  getAllWorkers(id:number): any {
    return this.http.get("http://localhost:59628/api/getWorkersDeatails/"+id);
  }
  getWorkersHours(id:number):any{
     return this.http.get("http://localhost:59628/api/getWorkersHours/"+id);
  }
  getProjectsHours(idTeamLeader:number,id:number):any{
     return this.http.get("http://localhost:59628/api/getWorkerHours/"+idTeamLeader+"/"+id);
  }

  setAlloactedHours(numHours:number, id:number):any{
  
     return this.http.put("http://localhost:59628/api/updateWorkerHours",{
      "numHours":numHours,
      "projectWorkerId":id
    });
  }
}
