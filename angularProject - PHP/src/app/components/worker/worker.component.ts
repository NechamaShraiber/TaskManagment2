import { Component, OnInit, Input } from '@angular/core';
import { Worker } from '../../shared/models/worker';
import { GlobalService } from '../../shared/service/global.service';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { WorkerDeatailsComponent } from '../worker-deatails/worker-deatails.component';
import { NavigationExtras, Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css', '../project/project.component.css']
})
export class WorkerComponent implements OnInit {
@Input() 
worker:Worker;
jobList: any[] = []; job: string;
  constructor(private globalService:GlobalService,private dialogService:DialogService, private teamLeaderService: TeamLeaderService, private router: Router) { }

  ngOnInit() {
     this.globalService.getAllJobs().subscribe(
       res => {
         this.jobList = res;
         this.job = this.jobList.find(p => p.Id == this.worker.JobId).Name;
       });
  }
  openWorkerDeatails() {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        "worker": JSON.stringify(this.worker)

      }
    };
    this.showWorker(); 
  }

  showWorker() {
    this.teamLeaderService.currentWorker=this.worker;
     this.dialogService.addDialog(WorkerDeatailsComponent, { 
    })
      .subscribe((isConfirmed) => { });
  }

}
