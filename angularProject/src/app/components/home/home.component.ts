import { Component, OnInit } from '@angular/core';
import { Worker } from '../../shared/models/worker';
import { Router } from '@angular/router';
import { WorkerService } from '../../shared/service/worker.service';
import { ManagerService } from '../../shared/service/manager.service';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { DeleteWorkerComponent } from '../delete-worker/delete-worker.component';
import { EditWorkerComponent } from '../edit-worker/edit-worker.component';
import { GlobalService } from '../../shared/service/global.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentWorker: Worker
  constructor(private workerService:WorkerService,private dialogService: DialogService, private managerService: ManagerService,
    private router:Router, private globalService:GlobalService) {
  }
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.workerService.idJob = this.currentWorker.JobId;
  }

  delete() {
    let disposable = this.dialogService.addDialog(DeleteWorkerComponent, {
      title: 'Delete Worker',
      message: 'Select Worker to delete'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.managerService.deleteWorker().subscribe(res => {

              alert('The worker deleted')},err=>
               alert('Can not delete'))}
      });
    setTimeout(() => {
      disposable.unsubscribe();
    }, 1000000);
  }
  edit(){
    let disposable = this.dialogService.addDialog(EditWorkerComponent, {
      title: "Edit Worker's detaild",
      message: 'Select Worker to edit'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.managerService.isEdit="Edit";
          this.router.navigate(['taskManagers/home/Addworker']);
        }
       
      });
    setTimeout(() => {
      disposable.unsubscribe();
    }, 1000000);
  }
  add(){
    this.managerService.isEdit="Add";
          this.router.navigate(['taskManagers/home/Addworker']);
  }
  logOut(){
    this.globalService.logOut();
  }
}

