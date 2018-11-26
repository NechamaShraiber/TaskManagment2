import { Component, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { ManagerService } from '../../shared/service/manager.service';
export interface ConfirmModel {
  title:string;
  message:string;
}
@Component({  
    selector: 'app-delete-worker',
    templateUrl: './delete-worker.component.html',
    styleUrls: ['./delete-worker.component.css']
})
export class DeleteWorkerComponent extends DialogComponent<ConfirmModel, boolean> implements ConfirmModel, OnInit {
 
  title: string;
  message: string;
  workerList: any[];
  selectUndefinedOptionValue:any;
  constructor(dialogService: DialogService,private managerService:ManagerService) {
    super(dialogService);
  }
  confirm() { 
    this.result= true;
    this.close();
  }
  ngOnInit(){
    this.workerList = [];
    this.managerService.getAllWorkers().subscribe(
      res=>{
        res.forEach(
          w => {
            if (w.JobId  > 2)
              this.workerList.push(w);
          });
    })
  }
  onChange(ev){
    this.managerService.idWorkerToDelete=this.workerList.find(p=>p.UserName==ev).Id;}
}