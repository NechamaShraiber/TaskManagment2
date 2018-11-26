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
  constructor(private http: HttpClient) { }
  getAllProjects(id:number): any {
    return this.http.get(GlobalService.path+"getProjectDeatails/"+id);
  }

  getAllWorkers(id:number): any {
    return this.http.get(GlobalService.path+"getWorkersDeatails/"+id);
  }

  getWorkersHours(id:number):any{
     return this.http.get(GlobalService.path+"getWorkersHours/"+id);
  }

  getProjectsHours(idTeamLeader:number,id:number):any{
     return this.http.get(GlobalService.path+"getWorkerHours/"+idTeamLeader+"/"+id);
  }
  
  setAlloactedHours(numHours:number, id:number):any{
     return this.http.put(GlobalService.path+"updateWorkerHours",{
      "numHours":numHours,
      "projectWorkerId":id
    });
  }
}
