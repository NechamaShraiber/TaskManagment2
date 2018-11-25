import { Component, OnInit, Injectable ,ViewChild} from '@angular/core';
import { ManagerService } from '../../shared/service/manager.service';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';

export interface UserData {
  WorkerName: string;
  ProjectName: string;
  Date: string;
  Start: string;
  End: string;

}
// const COLORS: string[] = ['maroon', 'red', 'orange', 'yellow', 'olive', 'green', 'purple',
//   'fuchsia', 'lime', 'teal', 'aqua', 'blue', 'navy', 'black', 'gray'];
// const NAMES: string[] = ['Maia', 'Asher', 'Olivia', 'Atticus', 'Amelia', 'Jack',
//   'Charlotte', 'Theodore', 'Isla', 'Oliver', 'Isabella', 'Jasper',
//   'Cora', 'Levi', 'Violet', 'Arthur', 'Mia', 'Thomas', 'Elizabeth'];

/**
 * Json node data with nested structure. Each node has a filename and a value or a list of children
 */
export class FileNode {
  children: FileNode[];
  filename: string;
  type: any;
}

@Injectable()
 export class FileDatabase implements OnInit {

  presence: any[];
  cols: any[];
  names: string[];
  public projectsByName: any[];
  projects: string[];
  projectHours: any[];
  projectNameAndHours: any[];
  dataChange = new BehaviorSubject<FileNode[]>([]);
  id: any;
  sub: any;

  get data(): FileNode[] { return this.dataChange.value; }
  displayedColumns: string[] = ['WorkerName', 'ProjectName', 'Date', 'Start','End'];
  dataSource: MatTableDataSource<UserData>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private managerService: ManagerService,private route: ActivatedRoute) {
    this.managerService.getPresence().subscribe(pre => {
      this.presence = pre;
      this.dataSource = new MatTableDataSource(this.presence);

     })
      this.sub = this.route.params.subscribe(params => {
     this.id = params.id;
     if(this.id==1){
      this.filterByNamesThenProjects();
     }
     if(this.id==2)
     {
       this.filterByProjectsThenNames();
     }
 })
 //const users = Array.from({length: 100}, (_, k) => this.createNewUser(k + 1));
 
 // Assign the data to the data source for the table to render
}
  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
   }
   
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


/** Builds and returns a new User. */
//  createNewUser(id: number): UserData {
//   const name =
//       NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
//       NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

//   return {
//     id: id.toString(),
//     name: name,
//     progress: Math.round(Math.random() * 100).toString(),
//     color: COLORS[Math.round(Math.random() * (COLORS.length - 1))]
//   };
// }

filterByNamesThenProjects(){
  this.managerService.getPresence().subscribe(pre => {
    this.presence = pre;
    this.names = [];
    this.projectsByName = [];
    console.log(this.presence+"    presence");

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
          if (pre.ProjectName == p&&pre.WorkerName==n)
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

filterByProjectsThenNames(){
  this.managerService.getPresence().subscribe(pre => {
    this.presence = pre;
    this.projects = [];
    this.projectsByName = [];
    console.log(this.presence);
    //filter all names
    this.presence.forEach(p => {
      if (!this.projects.find(n => n == p.ProjectName))
        this.projects.push(p.ProjectName);
      // root.children.push(p.WorkerName)
    });
    console.log(this.projects);
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
      console.log(this.names);
      this.projectNameAndHours = [];
      this.names.forEach(p => {
        this.projectHours = [];
        this.presence.forEach(pre => {
          if (pre.WorkerName == p&&pre.ProjectName==n)
            this.projectHours.push({
              Date: pre.Date,
              Start: pre.Start,
              End: pre.End

            })
        })
        console.log(this.projectHours);
        this.projectNameAndHours.push({
          workerName: p,
          hours: this.projectHours
        })
      })

      console.log(this.projectNameAndHours)
      this.projectsByName.push({
        name: n,
        workers: this.projectNameAndHours
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

  // exportToExcel1() {
  //   FileDatabase.exportToExcel()
  // }




//   import {Component, OnInit, ViewChild} from '@angular/core';
// import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';

// export interface UserData {
//   id: string;
//   name: string;
//   progress: string;
//   color: string;
// }

/** Constants used to fill up our data base. */
// const COLORS: string[] = ['maroon', 'red', 'orange', 'yellow', 'olive', 'green', 'purple',
//   'fuchsia', 'lime', 'teal', 'aqua', 'blue', 'navy', 'black', 'gray'];
// const NAMES: string[] = ['Maia', 'Asher', 'Olivia', 'Atticus', 'Amelia', 'Jack',
//   'Charlotte', 'Theodore', 'Isla', 'Oliver', 'Isabella', 'Jasper',
//   'Cora', 'Levi', 'Violet', 'Arthur', 'Mia', 'Thomas', 'Elizabeth'];

/**
 * @title Data table with sorting, pagination, and filtering.
 */

// export class TableOverviewExample implements OnInit {
//   displayedColumns: string[] = ['id', 'name', 'progress', 'color'];
//   dataSource: MatTableDataSource<UserData>;

//   @ViewChild(MatPaginator) paginator: MatPaginator;
//   @ViewChild(MatSort) sort: MatSort;

//   constructor() {
//     // Create 100 users
//     const users = Array.from({length: 100}, (_, k) => createNewUser(k + 1));

//     // Assign the data to the data source for the table to render
//     this.dataSource = new MatTableDataSource(users);
//   }

//   ngOnInit() {
//     this.dataSource.paginator = this.paginator;
//     this.dataSource.sort = this.sort;
//   }

//   applyFilter(filterValue: string) {
//     this.dataSource.filter = filterValue.trim().toLowerCase();

//     if (this.dataSource.paginator) {
//       this.dataSource.paginator.firstPage();
//     }
//   }
// }

// /** Builds and returns a new User. */
// function createNewUser(id: number): UserData {
//   const name =
//       NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
//       NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

//   return {
//     id: id.toString(),
//     name: name,
//     progress: Math.round(Math.random() * 100).toString(),
//     color: COLORS[Math.round(Math.random() * (COLORS.length - 1))]
//   };
// }

