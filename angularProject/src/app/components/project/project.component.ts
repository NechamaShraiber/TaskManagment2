import { Component,  Input, OnInit } from '@angular/core';
import { Project } from '../../shared/models/project';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { Router, NavigationExtras } from '../../../../node_modules/@angular/router';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { ProjectDeatailsComponent } from '../project-deatails/project-deatails.component';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit  {
  ngOnInit() {
    if(new Date(this.project["EndDate"])<new Date())
     this.status=true;
     else this.status=false;
  }
  @Input() project:Project;
  status:boolean;
  constructor(private teamLeaderService: TeamLeaderService, private router: Router, private dialogService:DialogService) {}

  openProjectDeatails() {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        "project": JSON.stringify(this.project)
      }
    };
   this.showProject(); 
  }
  
  showProject() {
    this.teamLeaderService.currentProject=this.project;
     this.dialogService.addDialog(ProjectDeatailsComponent, { 
    })
      .subscribe((isConfirmed) => { });
  }
}
