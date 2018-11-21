import { Component, OnInit , Injectable} from '@angular/core';
import { ManagerService } from '../../shared/service/manager.service';
import {NestedTreeControl} from '@angular/cdk/tree';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import {BehaviorSubject} from 'rxjs';

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
  projectsByName: any[];
  projects: string[];
  projectHours: any[];
  projectNameAndHours:any[];
  dataChange = new BehaviorSubject<FileNode[]>([]);

  get data(): FileNode[] { return this.dataChange.value; }

  constructor(private managerService: ManagerService) {
    //this.initialize();

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
          console.log(this.projectHours);

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
    this.initialize();

    });
  }

  initialize() {
    // Parse the string to json object.
    const dataObject = JSON.parse(JSON.stringify(this.projectsByName) );

    // Build the tree nodes from Json object. The result is a list of `FileNode` with nested
    //     file node as children.
    const data = this.buildFileTree(dataObject, 0);

    // Notify the change.
    this.dataChange.next(data);
  }

 
  buildFileTree(obj: {[key: string]: any}, level: number): FileNode[] {
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

  
  exportToExcel(){
     
    this.managerService.exportAsExcelFile(this.projectsByName);
   }
}

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css'],
  providers: [FileDatabase]

})
export class ReportsComponent implements OnInit {
  


    nestedTreeControl: NestedTreeControl<FileNode>;
    nestedDataSource: MatTreeNestedDataSource<FileNode>;
    

  constructor(database: FileDatabase,private managerService: ManagerService) { 
    this.nestedTreeControl = new NestedTreeControl<FileNode>(this._getChildren);
      this.nestedDataSource = new MatTreeNestedDataSource();
      database.dataChange.subscribe(data => this.nestedDataSource.data = data);
  }
  hasNestedChild = (_: number, nodeData: FileNode) => !nodeData.type;

  private _getChildren = (node: FileNode) => node.children;

  ngOnInit() {
   
  }

  
    }


