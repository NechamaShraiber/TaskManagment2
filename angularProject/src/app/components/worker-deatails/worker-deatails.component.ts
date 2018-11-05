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
      console.log(this.worker);
    });

    this.teamLeaderService.getProjectsHours(this.currentWorker.Id, this.worker.Id).subscribe(
      res => {
        this.projectsHours = res;
        console.log(res + "Gsdfg")
        console.log(this.projectsHours)
      });

  }

  changeHours(){
    alert("dsafdsaf"+this.projectId);
     this.teamLeaderService.setAlloactedHours(this.numHours,this.projectId).subscribe(
      res => {
    
       console.log(this.projectsHours);
     console.log(this.projectsHours.find(p=>p.Id==this.projectId));
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

  }
  setAllocatedHours(id:number){
 
   this.projectId=id;
  // alert(this.projectId);
   // document.querySelector('.cont_centrar').className = "cont_centrar cent_active";
   // console.log(  document.querySelector('.cont_centrar').attributes)  ;

  }
}

