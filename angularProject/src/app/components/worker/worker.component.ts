import { Component, OnInit, Input } from '@angular/core';
import { Worker } from '../../shared/models/worker';
import { GlobalService } from '../../shared/service/global.service';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css', '../project/project.component.css']
})
export class WorkerComponent implements OnInit {
@Input() 
worker:Worker;
jobList: any[] = []; job: string;
  constructor(private globalService:GlobalService) { }

  ngOnInit() {
    console.log(this.worker);
//     this.globalService.getAllJobs().subscribe(
//       res=>{
// console.log(res);
//       })
     
     this.globalService.getAllJobs().subscribe(
       res => {
         console.log(res)
         this.jobList = res;
         this.job = this.jobList.find(p => p.Id == this.worker.JobId).Name;
       });
  }

}
