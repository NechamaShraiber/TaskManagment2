import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { Project } from '../../shared/models/project';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { DialogService, DialogComponent } from '../../../../node_modules/ng2-bootstrap-modal';
export interface ConfirmModel {
  title:string;
  message:string;
}
@Component({
  selector: 'app-project-deatails',
  templateUrl: './project-deatails.component.html',
  styleUrls: ['./project-deatails.component.css']
})
export class ProjectDeatailsComponent  extends DialogComponent<ConfirmModel, boolean> implements ConfirmModel,OnInit {
private workersHours:any;
title: string;
  message: string;
  workerList: any;
  selectUndefinedOptionValue:any;
  constructor(dialogService: DialogService, private route:ActivatedRoute, private teamLeaderService:TeamLeaderService) {
    super(dialogService);
   }

  ngOnInit() {
      this.teamLeaderService.getWorkersHours(this.teamLeaderService.currentProject.Id).subscribe(
        res => {
          this.workersHours = res;
        })
}
  confirm() { 
    this.result= true;
    this.close();
  }
}
