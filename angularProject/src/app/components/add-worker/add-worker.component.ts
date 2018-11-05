import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ManagerService } from '../../shared/service/manager.service';
import { validate } from '../../shared/validate';
import sha256 from 'async-sha256';
import { GlobalService } from '../../shared/service/global.service';

@Component({
  selector: 'app-add-worker',
  templateUrl: './add-worker.component.html',
  styleUrls: ['./add-worker.component.css']
})
export class AddWorkerComponent implements OnInit {

  addWorkerGroup: FormGroup;
  //isExistUser: boolean = true;
  managerList: any[] = [];
  jobList: any[] = [];
  idManager: number;
  idJob: number;
  manager: string;
  job: string;
  selectUndefinedOptionValue: any;
  objectHolder: typeof Object = Object;

  constructor(private router: Router, private managerService: ManagerService, private globalService:GlobalService) {

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

  ngOnInit() {
    this.globalService.getAllJobs().subscribe(
      res => {
        console.log(res)
        this.jobList = res;
        this.job = this.jobList.find(p => p.Id == this.managerService.workerToUpdate.JobId).Name;
      });
    // this.managerService.getAllManagers().subscribe(
    //   res => {
    //     console.log(res)
    //     res.forEach(p => {
    //       if(p.JobId==this.idJob)
    //       {
    //       this.managerList.push(p);
    //       }
    //     });

    //     //this.managerList = res;
    //     this.manager = this.managerList.find(p => p.Id == this.managerService.workerToUpdate.ManagerId).Name;
    //   });
  }

  manag() {
    this.idJob = this.jobList.find(p => p.Id == this.addWorkerGroup.value["JobId"].Id);
    this.managerService.getAllManagers().subscribe(
      res => {
        console.log(res)
        res.forEach(p => {
          if (p.JobId < this.idJob["Id"]) {
            this.managerList.push(p);
          }
        });
      });
    //this.managerList = res;
    this.manager = this.managerList.find(p => p.Id == this.managerService.workerToUpdate.ManagerId).Name;
  }

  get f() { return this.addWorkerGroup.controls; }

  onSubmit() {
    this.idManager = this.managerList.find(p => p.Id == this.addWorkerGroup.value["ManagerId"].Id);
    this.addWorkerGroup.value["ManagerId"] = this.idManager["Id"];
    // this.idJob = this.jobList.find(p => p.Id == this.addWorkerGroup.value["JobId"].Id);
    this.addWorkerGroup.value["JobId"] = this.idJob["Id"];
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
      this.managerService.updateWorker(this.addWorkerGroup.value)
        .subscribe(worker => {
          if (worker == null) {
            alert("The worker's details edited succesfully")
            this.managerService.workerToUpdate = null;
            this.router.navigate(['taskManagers/home']);
          }
          else {
            this.router.navigate(['taskManagers/login'])
          }
        })
    }
  }
}