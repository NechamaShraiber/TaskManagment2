import { Component, OnInit} from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { ManagerService } from '../../shared/service/manager.service';
export interface ConfirmModel {
  title:string;
  message:string;
}
@Component({  
  selector: 'app-edit-worker',
  templateUrl: './edit-worker.component.html',
  styleUrls: ['./edit-worker.component.css','../delete-worker/delete-worker.component.css']
})
export class EditWorkerComponent extends DialogComponent<ConfirmModel, boolean> implements ConfirmModel, OnInit {
 
  title: string;
  message: string;
  workerList: any;
  selectUndefinedOptionValue:any;
  constructor(dialogService: DialogService,private managerService:ManagerService) {
    super(dialogService);
  }
  
  confirm() {
    this.result= true;
    this.close();
  }

  ngOnInit(){
    this.managerService.getAllWorkers().subscribe(
      res=>{
        this.workerList=res;
    })
  }

  onChange(ev){
    this.managerService.workerToUpdate.Id=this.workerList.find(p=>p.UserName==ev).Id;
    this.managerService.workerToUpdate.Name=this.workerList.find(p=>p.UserName==ev).Name;
    this.managerService.workerToUpdate.UserName=this.workerList.find(p=>p.UserName==ev).UserName;
    this.managerService.workerToUpdate.Password=this.workerList.find(p=>p.UserName==ev).Password;
    this.managerService.workerToUpdate.EMail=this.workerList.find(p=>p.UserName==ev).EMail;
    this.managerService.workerToUpdate.JobId=this.workerList.find(p=>p.UserName==ev).JobId;
    this.managerService.workerToUpdate.ManagerId=this.workerList.find(p=>p.UserName==ev).ManagerId;
  }
}
