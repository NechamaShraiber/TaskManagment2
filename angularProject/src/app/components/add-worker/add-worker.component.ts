import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ManagerService } from '../../shared/service/manager.service';
import { validate } from '../../shared/validate';

@Component({
  selector: 'app-add-worker',
  templateUrl: './add-worker.component.html',
  styleUrls: ['./add-worker.component.css']
})
export class AddWorkerComponent implements OnInit {

  addWorkerGroup: FormGroup;
  //isExistUser: boolean = true;
  managerList: any;
  jobList: any;
  idManager: number;
  idJob: number;
  manager: string;
  job: string;
  objectHolder: typeof Object = Object;
  constructor(private router: Router, private managerService: ManagerService) {
    this.managerService.getAllManagers().subscribe(
      res => {
        console.log(res)
        this.managerList = res;
        this.manager = this.managerList.find(p => p.Id == managerService.workerToUpdate.ManagerId).Name;
      });
    this.managerService.getAllJobs().subscribe(
      res => {
        console.log(res)
        this.jobList = res;
        this.job = this.jobList.find(p => p.Id == managerService.workerToUpdate.JobId).Name;
      });
    let formGroupConfig = {
      Name: new FormControl(managerService.workerToUpdate.Name, validate.createValidatorArr("Name", 2, 15)),
      UserName: new FormControl(managerService.workerToUpdate.UserName, validate.createValidatorArr("UserName", 2, 10)),
      Password: new FormControl(managerService.workerToUpdate.Password, validate.createValidatorArr("Password", 6, 10)),
      JobId: new FormControl(this.job),
      EMail: new FormControl(managerService.workerToUpdate.EMail, validate.createValidatorArr("EMail", 6, 30)),
      ManagerId: new FormControl(this.manager),
    };
    this.addWorkerGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() { }

  get f() { return this.addWorkerGroup.controls; }

  onSubmit() {
    this.idManager = this.managerList.find(p => p.Name == this.addWorkerGroup.value["ManagerId"]).Id;
    this.addWorkerGroup.value["ManagerId"] = this.idManager;
    this.idJob = this.jobList.find(p => p.Name == this.addWorkerGroup.value["JobId"]).Id;
    this.addWorkerGroup.value["JobId"] = this.idJob;
    if (this.managerService.isEdit == "Add") {
      this.managerService.addWorker(this.addWorkerGroup.value)
        .subscribe(worker => {
          if (worker == null) {
            alert("The worker added succesfully")
            this.router.navigate(['taskManagers/home']);
          }
          else {
            // this.isExistUser = false;
            this.router.navigate(['taskManagers/login'])
          }
        })
    } 
    else {
      this.managerService.isEdit = "Add"
      alert(this.managerService.isEdit)
    this.managerService.updateWorker(this.addWorkerGroup.value)
        .subscribe(worker => {
          if (worker == null) {
            alert("The worker's details edited succesfully")
            this.managerService.workerToUpdate=null;
            this.router.navigate(['taskManagers/home']);
          }
          else {
            this.router.navigate(['taskManagers/login'])
          }
        })
  }
}
}