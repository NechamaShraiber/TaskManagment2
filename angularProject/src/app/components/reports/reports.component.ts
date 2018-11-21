import { Component, OnInit, Injectable } from '@angular/core';
import { TreeNode } from '../../../../node_modules/@angular/router/src/utils/tree';
import { Project } from '../../shared/models/project';
import { ManagerService } from '../../shared/service/manager.service';
import { NG_PROJECT_AS_ATTR_NAME } from '../../../../node_modules/@angular/core/src/render3/interfaces/projection';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { BehaviorSubject } from 'rxjs';

/**
 * Json node data with nested structure. Each node has a filename and a value or a list of children
 */
export class FileNode {
  children: FileNode[];
  filename: string;
  type: any;
}



@Injectable()
 export class FileDatabase {

  presence: any[];
  cols: any[];
  names: string[];
  public projectsByName: any[];
  projects: string[];
  projectHours: any[];
  projectNameAndHours: any[];
  dataChange = new BehaviorSubject<FileNode[]>([]);

  get data(): FileNode[] { return this.dataChange.value; }

  constructor(private managerService: ManagerService) {
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
        this.projectNameAndHours = [];
        this.projects.forEach(p => {
          this.projectHours = [];
          this.presence.forEach(pre => {
            if (pre.ProjectName == p)
              this.projectHours.push({
                Date: pre.Date,
                Start: pre.Start,
                End: pre.End

              })
          })
          console.log(this.projectHours);

          this.projectNameAndHours.push({
            projectName: p,
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
      this.initialize();
    });
  }

  initialize() {
    // Parse the string to json object.
    const dataObject = JSON.parse(JSON.stringify(this.projectsByName));

    // Build the tree nodes from Json object. The result is a list of `FileNode` with nested
    //     file node as children.
    const data = this.buildFileTree(dataObject, 0);

    // Notify the change.
    this.dataChange.next(data);
  }

  /**
   * Build the file structure tree. The `value` is the Json object, or a sub-tree of a Json object.
   * The return value is the list of `FileNode`.
   */
  buildFileTree(obj: { [key: string]: any }, level: number): FileNode[] {
    return Object.keys(obj).reduce<FileNode[]>((accumulator, key) => {
      const value = obj[key];
      const node = new FileNode();
      node.filename = key;

      if (value != null) {
        if (typeof value === 'object') {
          node.children = this.buildFileTree(value, level + 1);
        } else {
          node.type = value;
        }
      }

      return accumulator.concat(node);
    }, []);
  }

  exportAsExcelFile() {
      this.managerService.exportAsExcelFile(this.projectsByName);
   }
   getFilterList(type:string){
this.projectsByName.forEach(p=>p.concat(type));
   }
}

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css'],
  providers: [FileDatabase]

})
export class ReportsComponent {

  nestedTreeControl: NestedTreeControl<FileNode>;
  nestedDataSource: MatTreeNestedDataSource<FileNode>;

  constructor(private database: FileDatabase, private managerService: ManagerService) {
    this.nestedTreeControl = new NestedTreeControl<FileNode>(this._getChildren);
    this.nestedDataSource = new MatTreeNestedDataSource();
    database.dataChange.subscribe(data => this.nestedDataSource.data = data);
  }
   exportToExcel() {
    this.database.exportAsExcelFile();
   }
  hasNestedChild = (_: number, nodeData: FileNode) => !nodeData.type;
  private _getChildren = (node: FileNode) => node.children;

  search(type) {
    this.database.getFilterList(type);
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



