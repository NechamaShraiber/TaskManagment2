import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { Worker } from '../../shared/models/worker';
import { DialogComponent, DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
export interface ConfirmModel {
  title: string;
  message: string;
}
@Component({
  selector: 'app-worker-deatails',
  templateUrl: './worker-deatails.component.html',
  styleUrls: ['./worker-deatails.component.css', '../project-deatails/project-deatails.component.css']
})
export class WorkerDeatailsComponent extends DialogComponent<ConfirmModel, boolean> implements ConfirmModel, OnInit {
  title: string;
  message: string;
  private projectsHours: any[];
  private worker: Worker;
  private currentWorker: Worker;
  private numHours: number = 0;
  private projectId: number;
  constructor(dialogService: DialogService, private route: ActivatedRoute, private teamLeaderService: TeamLeaderService) {
    super(dialogService);
  }
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.route.queryParams.subscribe(params => {
      this.worker = JSON.parse(params["worker"]);
    });

    this.teamLeaderService.getProjectsHours(this.currentWorker.Id, this.teamLeaderService.currentWorker["Id"]).subscribe(
      res => {
        this.projectsHours = res;
      });
  }

  changeHours() {
    if (this.numHours != this.projectsHours.find(p => p.Id == this.projectId).AllocatedHours)
      this.teamLeaderService.setAlloactedHours(this.numHours, this.projectId).subscribe(
        res => {
          this.projectsHours.find(p => p.Id == this.projectId).AllocatedHours = this.numHours;
          this.projectId = null;
        })
    else
      this.projectId = null;

  }
  setAllocatedHours(id: number) {
    this.projectId = id;
    this.numHours = this.projectsHours.find(p => p.Id == id).AllocatedHours;
  }
  confirm() {
    this.result = true;
    this.close();
  }
}

