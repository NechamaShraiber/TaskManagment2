import { Component, OnInit } from '@angular/core';
import { Worker } from '../../shared/models/worker';
import { Router } from '@angular/router';
import { WorkerService } from '../../shared/service/worker.service';
import { ManagerService } from '../../shared/service/manager.service';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { DeleteWorkerComponent } from '../delete-worker/delete-worker.component';
import { EditWorkerComponent } from '../edit-worker/edit-worker.component';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentWorker: Worker
  constructor(private workerService:WorkerService,private dialogService: DialogService, private managerService: ManagerService,private router:Router) {
  }
  //id: number
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));

    this.workerService.idJob = this.currentWorker.JobId;
    // if (this.workerService.idJob >= 3) {
    //   this.router.navigate(['taskManagers/homeWorkerComponent']);
    // }
  }


  delete() {
    let disposable = this.dialogService.addDialog(DeleteWorkerComponent, {
      title: 'Delete Worker',
      message: 'Select Worker to delete'
    })
      .subscribe((isConfirmed) => {
        //We get dialog result
        if (isConfirmed) {
          this.managerService.deleteWorker().subscribe(res => {
            if (!res)
              alert('The worker deleted')
              else alert('Can not delete')
          })
        }
        else {
          //alert('declined');
        }
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
        else {
          //alert('Can not edit this worker');
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

}

