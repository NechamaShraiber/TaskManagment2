import { Component, OnInit, Input } from '@angular/core';
import { TeamLeaderService } from '../../shared/service/team-leader.service';
import { Worker } from '../../shared/models/worker'
@Component({
  selector: 'app-team-leader-project',
  templateUrl: './team-leader-project.component.html',
  styleUrls: ['./team-leader-project.component.css']
})
export class TeamLeaderProjectComponent implements OnInit {
  private projects: any;
  currentWorker: Worker;
  constructor(private teamLeaderService: TeamLeaderService ) { }
  // @Input()
  // private id: number
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.teamLeaderService.getAllProjects(this.currentWorker.Id).subscribe(
      res => {
        this.projects = res;
      })

  }

  

}
