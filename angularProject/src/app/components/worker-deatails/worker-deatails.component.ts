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
  constructor(private route: ActivatedRoute, private teamLeaderService: TeamLeaderService) { }

  ngOnInit() {
  this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.route.queryParams.subscribe(params => {
      this.worker = JSON.parse(params["worker"]);
      console.log(this.worker);
    });

    this.teamLeaderService.getProjectsHours(this.currentWorker.Id, this.worker.Id).subscribe(
      res => {
        this.projectsHours = res;
        console.log(res + "Gsdfg")
        console.log(this.projectsHours)
      });

  }
  setAllocatedHours(id:number){
    console.log(id)
    this.teamLeaderService.setAlloactedHours(this.numHours,id).subscribe(
      res => {
      
       console.log(this.projectsHours);
     console.log(this.projectsHours.find(p=>p.Id==id));
       this.projectsHours.find(p=>p.Id==id).AllocatedHours=this.numHours;
       // .forEach(element => {

      //    if(element.Id==id)
      //    {
      //      console.log(element.AlloactedHours)
      //    element.AlloactedHours=this.numHours;
      //    }
         
      
         
      //  }); 
      })

  }
}

