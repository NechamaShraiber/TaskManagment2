import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from '../models/project';
import { Worker } from '../models/worker';
import { GlobalService } from './global.service';
@Injectable({
  providedIn: 'root'
})
export class TeamLeaderService {
  
currentProject:Project;
currentWorker:Worker;
URLPHPUSERS: string = "http://localhost/TaskManagment/UIL/index.php"
  constructor(private http: HttpClient) { }
  getAllProjects(id:number): any {
  //  return this.http.get(GlobalService.path+"getProjectDeatails/"+id);
    return this.http.get(this.URLPHPUSERS+"?funcation=getProjectDeatails&id="+id);

  }

  getAllWorkers(id:number): any {
    //return this.http.get(GlobalService.path+"getWorkersDeatails/"+id);
    return this.http.get(this.URLPHPUSERS+"?funcation=getWorkersDeatails&id="+id);

  }

  getWorkersHours(id:number):any{
   //  return this.http.get(GlobalService.path+"getWorkersHours/"+id);
    return this.http.get(this.URLPHPUSERS+"?funcation=getWorkersHours&id="+id);

  }

  getProjectsHours(idTeamLeader:number,id:number):any{
    // return this.http.get(GlobalService.path+"getWorkerHours/"+idTeamLeader+"/"+id);
     return this.http.get(this.URLPHPUSERS+"?funcation=getWorkerHours&idTeamLeader="+idTeamLeader+"&id="+id);
  }
  
  setAlloactedHours(numHours:number, id:number):any{
     return this.http.put(GlobalService.path+"updateWorkerHours",{
      "numHours":numHours,
      "projectWorkerId":id
    });
  }
  getRemainingHours(projectId: number): any {
   //return this.http.get(GlobalService.path+"getRemainingHours/"+projectId+"/"+this.currentWorker.JobId);
    return this.http.get(this.URLPHPUSERS+"?funcation=getRemainingHours&projectId="+projectId+"&JobId="+this.currentWorker.JobId);
    
  }
}
