import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ManagerService } from '../../shared/service/manager.service';
import { validate } from '../../shared/validate';
import { GlobalService } from '../../shared/service/global.service';
import { Job } from '../../shared/models/job';
import { Worker } from '../../shared/models/worker';

@Component({
  selector: 'app-add-worker',
  templateUrl: './add-worker.component.html',
  styleUrls: ['./add-worker.component.css']
})
export class AddWorkerComponent implements OnInit {

  addWorkerGroup: FormGroup;
  managerList: any[] = [];
  jobList: Job[] = [];
  idManager: number;
  manager: any;
  idJob:number;
  job:any;
  selectUndefinedOptionValue: any;
  objectHolder: typeof Object = Object;
  constructor(private router: Router, private managerService: ManagerService, private globalService:GlobalService) {
    let formGroupConfig = {
      Name: new FormControl(managerService.workerToUpdate.Name?managerService.workerToUpdate.Name:" ", validate.createValidatorArr("Name", 2, 15)),
      UserName: new FormControl(managerService.workerToUpdate.UserName, validate.createValidatorArr("UserName", 2, 10)),
      Password: new FormControl("", validate.createValidatorArr("Password", 6, 10)),
      JobId: new FormControl(this.job),
      EMail: new FormControl(managerService.workerToUpdate.EMail?managerService.workerToUpdate.EMail:" ", validate.createValidatorArr("EMail", 6, 30)),
      ManagerId: new FormControl(this.manager),
    };
    this.addWorkerGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    this.globalService.getAllJobs().subscribe(
      res => {
        this.jobList = res;
        this.job = this.jobList.find(p => p.Id == this.managerService.workerToUpdate["JobId"]).Name;
        this.idJob = this.jobList.find(p => p.Id == this.managerService.workerToUpdate["JobId"]).Id;
         this.managerService.getAllManagers().subscribe(res => {
           this.managerList= [];
            res.forEach(p => {
                this.managerList.push(p);
            });
           //for edit
          // this.manager = this.managerList.find(p=>p.Id== this.managerService.workerToUpdate["ManagerId"]).Name;
           //this.idManager = this.managerList.find(p=>p.Id== this.managerService.workerToUpdate["ManagerId"]).Id;
          });
      });
  }

  manag() {
    this.idJob = this.jobList.find(p => p.Name == this.addWorkerGroup.value["JobId"]).Id;
    this.managerService.getAllManagers().subscribe(
      res => {
       this.managerList= [];
        res.forEach(p => {
          if (p.JobId < this.idJob) {
            this.managerList.push(p);
          }
        });
      });
    this.manager = this.managerList.find(p => p.Id == this.managerService.workerToUpdate["ManagerId"]).Name;
  }

  get f() { return this.addWorkerGroup.controls; }

  onSubmit() {
    //If it for "ADD"
    if (this.managerService.isEdit == "Add") {
      //Saves the id of manager and job
    this.addWorkerGroup.value["ManagerId"]?this.addWorkerGroup.value["ManagerId"] =this.managerList.find(p=>p.Name==this.addWorkerGroup.value["ManagerId"]).Id:this.addWorkerGroup.value["ManagerId"]=this.managerList[0].Id;
    // this.addWorkerGroup.value["ManagerId"] = this.idManager;
    this.addWorkerGroup.value["JobId"]?this.idJob =this.jobList.find(p=>p.Name==this.addWorkerGroup.value["JobId"]).Id:this.idJob=this.jobList[0].Id;
    this.addWorkerGroup.value["JobId"] = this.idJob;
      this.managerService.addWorker(this.addWorkerGroup.value)
        .subscribe(worker => {
            alert("The worker added succesfully")
            this.router.navigate(['taskManagers/home']);
          },err=>
          {
            alert("Can not add the worker")
            this.router.navigate(['taskManagers/home'])}
          )}
    
    else {
      //If it for "EDIT"
     this.managerService.isEdit = "Add"
     //Saves the id of manager and job
     this.addWorkerGroup.value["ManagerId"]?this.addWorkerGroup.value["ManagerId"]=this.managerList.find(p=>p.Name== this.addWorkerGroup.value["ManagerId"]).Id:this.addWorkerGroup.value["ManagerId"] =this.idManager;
     this.addWorkerGroup.value["JobId"]?this.addWorkerGroup.value["JobId"]=(this.jobList.find(p=>p.Name== this.addWorkerGroup.value.JobId).Id):this.addWorkerGroup.value["JobId"] =this.idJob;
      this.managerService.updateWorker(this.addWorkerGroup.value)
        .subscribe(worker => {
            alert("The worker's details edited succesfully")
            this.managerService.workerToUpdate = new Worker();
            this.router.navigate(['taskManagers/home']);
          },err=>
         {
          alert("Can not edit the worker")
            this.router.navigate(['taskManagers/home'])
          }
        )
    }
  }
}