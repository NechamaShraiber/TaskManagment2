import { Component, OnInit } from '@angular/core';
import { TreeNode } from '../../../../node_modules/@angular/router/src/utils/tree';
import { Project } from '../../shared/models/project';
import { ManagerService } from '../../shared/service/manager.service';
import { NG_PROJECT_AS_ATTR_NAME } from '../../../../node_modules/@angular/core/src/render3/interfaces/projection';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  presence: any[];
  cols: any[];
  names: string[];
  projectsByName: any[];
  projects: string[];
  projectHours: any[];
  projectNameAndHours:any[];
  constructor(private managerService: ManagerService) { }

  ngOnInit() {
    this.managerService.getPresence().subscribe(pre => {
      this.presence = pre;
      this.names = [];
      this.projectsByName = [];
      console.log(this.presence);
      //filter all names
      this.presence.forEach(p => {
        if (!this.names.find(n => n == p.WorkerName))
          this.names.push(p.WorkerName);
      });
      console.log(this.names);
      //about every name filter project name and hours
      this.names.forEach(n => {
        this.projects = [];
      
        this.presence.forEach(p => {
          if (p.WorkerName == n) {
            if (!this.projects.find(pro => pro == p.ProjectName))
              this.projects.push(p.ProjectName)
           }
        })
        console.log(this.projects);
        this.projectNameAndHours=[];
        this.projects.forEach(p=>{
          this.projectHours = [];
          this.presence.forEach(pre=>
          {
            if(pre.ProjectName==p)
             this.projectHours.push({
          Date: pre.Date,
          Start: pre.Start,
          End: pre.End

        })
          })


this.projectNameAndHours.push({
            projectName:p,
            hours: this.projectHours
          })
        })
        
       console.log(this.projectNameAndHours)
        this.projectsByName.push({
          name: n,
          projects: this.projectNameAndHours

        })
      });
      console.log(this.projectsByName);
    });
    this.cols = [
      { field: 'WorkerName', header: 'WorkerName' },
      { field: 'ProjectName', header: 'ProjectName' }
    ];
  }

}