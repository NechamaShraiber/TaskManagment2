import { Component, Injectable } from '@angular/core';
import { ManagerService } from '../../shared/service/manager.service';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';

/**
 * Json node data with nested structure. Each node has a filename and a value or a list of children
 */
export class FileNode {
  children: FileNode[];
  filename: string;
  type: any;
}

@Injectable()
 export class FileDatabase{
 
  presence: any[];
 // filterPresence: any[];
  cols: any[];
  names: string[];
  public projectsByName: any[];
  projects: string[];
  projectHours: string[];
  projectNameAndHours: any[];
  dataChange = new BehaviorSubject<FileNode[]>([]);
  get data(): FileNode[] { return this.dataChange.value; }
  paramsId:any;
  constructor(private managerService: ManagerService,private activatedRoute: ActivatedRoute) { 
   
    this.activatedRoute.params.subscribe(params => {
      this.paramsId = params['id'];
      if(this.paramsId==1)
      this.filterByNamesThenProjects();
      else if(this.paramsId==2)
      this.filterByProjectsThenNames();
      
      });
    this.managerService.getPresence().subscribe(pre => {
      this.presence = pre;
     // this.filterPresence=pre;
      this.names = [];
      this.projectsByName = [];
      //filter all names
      this.presence.forEach(p => {
        if (!this.names.find(n => n == p.WorkerName))
          this.names.push(p.WorkerName);
      });
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
    });
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
    const dataObject = this.projectsByName;
    const data = this.buildFileTree(dataObject, 0);
    this.dataChange.next(data);
  }

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
  parameter
  searchByWorker:string;
  searchByProject:string;
  searchByMonth:string;
  //Params for basic table
   displayedColumns: string[] = ['WorkerName', 'ProjectName', 'Date', 'Start','End'];
   dataSource;
   filterDataSource;
  nestedTreeControl: NestedTreeControl<FileNode>;
  nestedDataSource: MatTreeNestedDataSource<FileNode>;
  constructor(private database: FileDatabase, private managerService: ManagerService) {
    this.nestedTreeControl = new NestedTreeControl<FileNode>(this._getChildren);
    this.nestedDataSource = new MatTreeNestedDataSource();
    database.dataChange.subscribe(data => this.nestedDataSource.data = data);
   managerService.getPresence().subscribe(res=>{this.dataSource=res;this.filterDataSource=res})
  }
  
   exportToExcel() {
    this.database.exportAsExcelFile();
   }
   month(month)
   {
    var x =new Date(month);
    var t=x.getMonth()
    var x2= t.toString();
    return x2;
   
   }
search(){

 this.dataSource=this.filterDataSource;
 if(this.searchByWorker!=null &&this.searchByWorker!="")
 this.dataSource=this.dataSource.filter(f=>f.WorkerName==this.searchByWorker);
 if(this.searchByProject!=null&&this.searchByProject!="")
 this.dataSource=this.dataSource.filter(f=>f.ProjectName==this.searchByProject);
  if(this.searchByMonth!=null &&this.searchByMonth!="null")
  {
    this.dataSource=this.dataSource.filter(f=>
     this.month(f.Date)==this.searchByMonth
    );
  }
}

  hasNestedChild = (_: number, nodeData: FileNode) => !nodeData.type;
  private _getChildren = (node: FileNode) => node.children;
  }

  