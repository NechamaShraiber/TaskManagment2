import { Component, OnInit, Output, Input } from '@angular/core';
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
  workerList: any;
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
    this.managerService.idWorkerToDelete=this.workerList.find(p=>p.UserName==ev).Id;}
}