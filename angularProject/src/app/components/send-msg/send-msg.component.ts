import { Component  } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { WorkerService } from '../../shared/service/worker.service';
export interface ConfirmModel {
  title:string;
  message:string;
}
@Component({
  selector: 'app-send-msg',
  templateUrl: './send-msg.component.html',
  styleUrls: ['./send-msg.component.css']
})
export class SendMsgComponent extends DialogComponent<ConfirmModel, boolean> implements ConfirmModel  {
  title: string;
  message: string;
  workerList: any;
  constructor(dialogService: DialogService,private workerService:WorkerService) {
    super(dialogService);
  }
  confirm() {
    this.workerService.subStr=this.title;
    this.workerService.bodyStr=this.message;
    this.result= true;
    this.close();
  }
  x
}