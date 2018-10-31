import { Component, OnInit, Input } from '@angular/core';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { Worker } from '../../shared/models/worker'
import { Project } from '../../shared/models/project';
import { Router, NavigationExtras } from '../../../../node_modules/@angular/router';
//import { createWiresService } from '../../../node_modules/@types/selenium-webdriver/firefox';
@Component({
  selector: 'app-team-leader-project',
  templateUrl: './team-leader-project.component.html',
  styleUrls: ['./team-leader-project.component.css']
})
export class TeamLeaderProjectComponent implements OnInit {
  private projects: any;
  currentWorker: Worker;
  constructor(private teamLeaderService: TeamLeaderService, private router:  Router) 
{ }
  @Input()
  private id: number
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.teamLeaderService.getAllProjects(this.currentWorker.Id).subscribe(
      res => {
        this.projects = res;
        console.log(this.projects)
      })

  }

  

 openProjectDeatails(project: Project) {
  let navigationExtras: NavigationExtras = {
    queryParams: {
        "project":JSON.stringify(project)
      
    }
};
  this.router.navigate([`taskManagers/projectDeatails`],navigationExtras );
}
}
