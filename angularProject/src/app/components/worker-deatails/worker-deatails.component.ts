import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { Worker } from '../../shared/models/worker';

@Component({
  selector: 'app-worker-deatails',
  templateUrl: './worker-deatails.component.html',
  styleUrls: ['./worker-deatails.component.css']
})
export class WorkerDeatailsComponent implements OnInit {
  private projectsHours: any[];
  private worker: Worker;
  private currentWorker: Worker;
private numHours:number=0;
private projectId:number;
  constructor(private route: ActivatedRoute, private teamLeaderService: TeamLeaderService) { }

  ngOnInit() {
  this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.route.queryParams.subscribe(params => {
      this.worker = JSON.parse(params["worker"]);
    });

    this.teamLeaderService.getProjectsHours(this.currentWorker.Id, this.worker.Id).subscribe(
      res => {
        this.projectsHours = res;
       
      });

  }

  changeHours(){
    if(this.numHours!=this.projectsHours.find(p=>p.Id==this.projectId).AllocatedHours)
     this.teamLeaderService.setAlloactedHours(this.numHours,this.projectId).subscribe(
      res => {
    
       this.projectsHours.find(p=>p.Id==this.projectId).AllocatedHours=this.numHours;
         this.projectId=null;
       // .forEach(element => {

      //    if(element.Id==id)
      //    {
      //      console.log(element.AlloactedHours)
      //    element.AlloactedHours=this.numHours;
      //    }
         
      
         
      //  }); 
      })
      else
      this.projectId=null;

  }
  setAllocatedHours(id:number){
 
   this.projectId=id;
   this.numHours=this.projectsHours.find(p=>p.Id==id).AllocatedHours;
  }
}

