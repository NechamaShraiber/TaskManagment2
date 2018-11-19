import { Component, OnInit } from '@angular/core';
import { TreeNode } from '../../../../node_modules/@angular/router/src/utils/tree';
import { Project } from '../../shared/models/project';
import { ManagerService } from '../../shared/service/manager.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  presence: any[];
  cols: any[];
names:string[];
  constructor(private managerService: ManagerService) { }

  ngOnInit() {
      this.managerService.getPresence().subscribe(pre =>{ 
        this.presence = pre;
        console.log(this.presence);
     this.names=this.presence.filter(p=>p.WorkerName);
     console.log(this.names)
      });
      this.cols = [
          { field: 'WorkerName', header: 'WorkerName' },
          {field: 'ProjectName', header: 'ProjectName' }
      ];
  }

}
