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
  projectHours: string[];
  projectNameAndHours: any[];
  dataChange = new BehaviorSubject<FileNode[]>([]);

  get data(): FileNode[] { return this.dataChange.value; }

  constructor(private managerService: ManagerService) {
    this.managerService.getPresence().subscribe(pre => {
      this.presence = pre;
      this.names = [];
      this.projectsByName = [];
      //filter all names
      this.presence.forEach(p => {
        if (!this.names.find(n => n == p.WorkerName))
          this.names.push(p.WorkerName);
        // root.children.push(p.WorkerName)
      });
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
        this.projectNameAndHours = [];
        this.projects.forEach(p => {
          this.projectHours = [];
          this.presence.forEach(pre => {
            if (pre.ProjectName == p)
              this.projectHours.push(
                pre.Date+" "+
                pre.Start+" "+
               pre.End
              )
          })
          this.projectNameAndHours.push({
            projectName: p,
            hours: this.projectHours
          })
        })

        this.projectsByName.push({
          name: n,
          projects: this.projectNameAndHours
        })
      });
       this.initialize();
    this.filterByProjectsThenNames();
  })
}
filterByNamesThenProjects(){
  this.managerService.getPresence().subscribe(pre => {
    this.presence = pre;
    this.names = [];
    this.projectsByName = [];
    //filter all names
    this.presence.forEach(p => {
      if (!this.names.find(n => n == p.WorkerName))
        this.names.push(p.WorkerName);
      // root.children.push(p.WorkerName)
    });
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
      this.projectNameAndHours = [];
      this.projects.forEach(p => {
        this.projectHours = [];
        this.presence.forEach(pre => {
          if (pre.ProjectName == p&&pre.WorkerName==n)
            this.projectHours.push( pre.Date+" "+
            pre.Start+" "+
           pre.End)
        })

        this.projectNameAndHours.push({
          projectName: p,
          hours: this.projectHours
        })
      })

      this.projectsByName.push({
        name: n,
        projects: this.projectNameAndHours
      })
    });
    this.initialize();
  });
}
filterByProjectsThenNames(){
  this.managerService.getPresence().subscribe(pre => {
    this.presence = pre;
    this.projects = [];
    this.projectsByName = [];
    //filter all names
    this.presence.forEach(p => {
      if (!this.projects.find(n => n == p.ProjectName))
        this.projects.push(p.ProjectName);
      // root.children.push(p.WorkerName)
    });
    ;
    //about every name filter project name and hours
    this.projects.forEach(n => {
      this.names = [];
      this.presence.forEach(p => {
        if (p.ProjectName == n) {
          if (!this.names.find(pro => pro == p.WorkerName))
            this.names.push(p.WorkerName)
        }
      })
      this.projectNameAndHours = [];
      this.names.forEach(p => {
        this.projectHours = [];
        this.presence.forEach(pre => {
          if (pre.WorkerName == p&&pre.ProjectName==n)
            this.projectHours.push(
              pre.Date+" "+
              pre.Start+" "+
             pre.End

            )
        })

        this.projectNameAndHours.push({
          workerName: p,
          hours: this.projectHours
        })
      })

      this.projectsByName.push({
        name: n,
        workers: this.projectNameAndHours
      })
    });
    this.initialize();
  });
}
  initialize() {
    // Parse the string to json object.
    const dataObject = this.projectsByName;
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
      this.managerService.exportAsExcelFile(this.presence);
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
    //this.database.getFilterList(type);
  }
  }



