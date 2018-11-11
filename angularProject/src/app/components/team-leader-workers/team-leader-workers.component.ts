import { Component, OnInit } from '@angular/core';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { Worker } from '../../shared/models/worker';
import { NavigationExtras, Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-team-leader-workers',
  templateUrl: './team-leader-workers.component.html',
  styleUrls: ['./team-leader-workers.component.css']
})
export class TeamLeaderWorkersComponent implements OnInit {
  currentWorker: Worker;
  private workers: any;
  constructor(private teamLeaderService: TeamLeaderService, private router: Router) { }

  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.teamLeaderService.getAllWorkers(this.currentWorker.Id).subscribe(
      res => {
        this.workers = res;
      })
  }
  openWorkerDeatails(worker: Worker) {

    let navigationExtras: NavigationExtras = {
      queryParams: {
        "worker": JSON.stringify(worker)

      }
    };
    this.router.navigate([`taskManagers/WorkerDeatails`], navigationExtras);
  }
}
