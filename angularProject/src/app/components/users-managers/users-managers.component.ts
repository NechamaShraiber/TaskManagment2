import { Component, OnInit, Input } from '@angular/core';
import { DeleteWorkerComponent } from '../delete-worker/delete-worker.component';
import { DialogService } from "ng2-bootstrap-modal";
import { ManagerService } from '../../shared/service/manager.service';
import { EditWorkerComponent } from '../edit-worker/edit-worker.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users-managers',
  templateUrl: './users-managers.component.html',
  styleUrls: ['./users-managers.component.css']
})
export class UsersManagersComponent implements OnInit {

  constructor(private dialogService: DialogService, private managerService: ManagerService,private router:Router) {
   }

  ngOnInit() {
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

