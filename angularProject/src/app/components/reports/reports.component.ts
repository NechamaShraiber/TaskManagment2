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
    // let root={
    //   data: {
    //     name: "vvv",
    //   },
    //   children: []
    // };
    this.managerService.getPresence().subscribe(pre => {
      this.presence = pre;
      this.names = [];
      this.projectsByName = [];
      console.log(this.presence);
      //filter all names
      this.presence.forEach(p => {
        if (!this.names.find(n => n == p.WorkerName))
          this.names.push(p.WorkerName);
          // root.children.push(p.WorkerName)
      });
      console.log(this.names);
      ;
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
      { field: 'ProjectName', header: 'ProjectName' },
      { field: 'Start', header: 'Start' },
      { field: 'End', header: 'End' },
    ];
  }

  exportToExcel(){
     
     this.managerService.exportAsExcelFile(this.presence);
    }
  
    }
/*

getProjectInfo(project: TreeTable) {
    //let projectDays: number = this.baseService.dateDiffInDays(project.startDate, project.endDate);
    // let date = new Date();
    // if (date > project.endDate)
    //   date = project.endDate;
    // let workedDays: number = this.baseService.dateDiffInDays(project.startDate, date);
    // let daysPercent: number = workedDays / projectDays;

    // let projectPresenseHours: number = this.projectService.getPresenceHours(project);
    // let projectPercentHours: number = this.projectService.getPercentHours(project);
    // let state: string;

    // if (projectPercentHours == daysPercent)
    //   state = "good";
    // else
    //   if (projectPercentHours > daysPercent)
    //     state = "excellent";
    //   else
    //     state = "bad"
    let hours = project.Project.QaHours + project.Project.UiUxHours + project.Project.DevelopersHours;
    let actualhorsForProject = this.getActualHoursForProject(project);
    // console.log("hh", this.teamLeader);
    let root = {
      data: {
        name: "vvv",
      },
      children: []
    };
    let actualHoursForDepartment = this.getActualHoursForDepartment(project, "DevelopersHours")
    let departmentNode = {
      data: {
        name: "DevelopersHours",
        hours: project.Project.DevelopersHours,
        actualHours: actualHoursForDepartment,
        percent: this.getPrecentOfNumbers(hours, actualHoursForDepartment),
        // presence: this.baseService.toShortNumber(presenceHoursForDepartment),
        // percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
      },

      children: [

      ]
    };
    project.DetailsWorkerInProjects.forEach(worker => {


      if (worker.Kind == "Developers") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            hours: worker.Hours,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName
            // presence: this.baseService.toShortNumber(presenceHoursForWorker),
            // percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
        departmentNode.children.push(workerNode);
      }
    })
    root.children.push(departmentNode);
    let actualHoursForDepartment1 = this.getActualHoursForDepartment(project, "QaHours");
    let departmentNode1 = {
      data: {
        name: "QaHours",
        hours: project.Project.QaHours,
        actualHours: actualHoursForDepartment1,
        percent: this.getPrecentOfNumbers(hours, actualHoursForDepartment1),
        // presence: this.baseService.toShortNumber(presenceHoursForDepartment),
        // percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
      },

      children: [

      ]
    };

    project.DetailsWorkerInProjects.forEach(worker => {
      if (worker.Kind == "QA") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            hours: worker.Hours,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName
            // presence: this.baseService.toShortNumber(presenceHoursForWorker),
            // percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
        departmentNode1.children.push(workerNode);
      }
    })
    root.children.push(departmentNode1);
    let actualHoursForDepartment2 = this.getActualHoursForDepartment(project, "UiUxHours");
    let departmentNode2 = {
      data: {
        name: "UiUxHours",
        hours: project.Project.UiUxHours,
        actualHours: actualHoursForDepartment2,
        percent: this.getPrecentOfNumbers(hours, actualHoursForDepartment2),
        // presence: this.baseService.toShortNumber(presenceHoursForDepartment),
        // percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
      },
      children: [

      ]
    };

    project.DetailsWorkerInProjects.forEach(worker => {
      if (worker.Kind == "UI/UX") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName,
            hours: worker.Hours
            // presence: this.baseService.toShortNumber(presenceHoursForWorker),
            // percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
        departmentNode2.children.push(workerNode);
      }
    })
    root.children.push(departmentNode2);
    return <TreeNode>(root);
  }

*/  



