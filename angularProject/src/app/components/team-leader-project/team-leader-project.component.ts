import { Component, OnInit, Input } from '@angular/core';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { Worker } from '../../shared/models/worker'
import { Project } from '../../shared/models/project';
import { Router, NavigationExtras } from '../../../../node_modules/@angular/router';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { ProjectDeatailsComponent } from '../project-deatails/project-deatails.component';
//import { createWiresService } from '../../../node_modules/@types/selenium-webdriver/firefox';
@Component({
  selector: 'app-team-leader-project',
  templateUrl: './team-leader-project.component.html',
  styleUrls: ['./team-leader-project.component.css']
})
export class TeamLeaderProjectComponent implements OnInit {
  private projects: any;
  currentWorker: Worker;
  constructor(private teamLeaderService: TeamLeaderService, private router: Router, private dialogService:DialogService) { }
  @Input()
  private id: number
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.teamLeaderService.getAllProjects(this.currentWorker.Id).subscribe(
      res => {
        this.projects = res;
      })

  }

  openProjectDeatails(project: Project) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        "project": JSON.stringify(project)
      }
    };
   this.showProject(project); 
  }

  showProject(project) {
    this.teamLeaderService.currentProject=project;
     this.dialogService.addDialog(ProjectDeatailsComponent, { 
    })
      .subscribe((isConfirmed) => { });
  }

}
