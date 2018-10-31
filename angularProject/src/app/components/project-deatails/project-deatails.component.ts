import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { Project } from '../../shared/models/project';
import { TeamLeaderService } from '../../shared/service/team-leader.service';

@Component({
  selector: 'app-project-deatails',
  templateUrl: './project-deatails.component.html',
  styleUrls: ['./project-deatails.component.css']
})
export class ProjectDeatailsComponent implements OnInit {
private project:Project;
private workersHours:any;
  constructor(private route:ActivatedRoute, private teamLeaderService:TeamLeaderService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
   
      this.project=JSON.parse(params["project"]) ;
      this.teamLeaderService.getWorkersHours(this.project.Id).subscribe(
        res => {
          this.workersHours = res;
            console.log(res+"Gsdfg")
          console.log(this.workersHours)
        })
  
      //{Id: null, Name: "Pnina", Date: "2018-10-25T00:00:00", Hours: "00:03:22", allocatedHours: 0}
//1: {Id: null, Name: "Rachel", Date: "2018-10-25T00:00:00", Hours: "00:12:20", allocatedHours: 1}
});

}
}
