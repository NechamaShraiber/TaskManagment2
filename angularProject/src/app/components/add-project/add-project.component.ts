import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ManagerService } from '../../shared/service/manager.service';
import { validate } from '../../shared/validate';
import { Worker } from '../../shared/models/worker';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  addProjectGroup: FormGroup;
  teamLeader: any[] = [];
  idTeam: number;
  objectHolder: typeof Object = Object;
  date: any;
  workers: Worker[];
  workersToSelect: Worker[];
  workersToAdd: Worker[] = [];
  constructor(private router: Router, private managerService: ManagerService) {
    let formGroupConfig = {
      Name: new FormControl('', validate.createValidatorArr("Name", 2, 25)),
      Customer: new FormControl('', validate.createValidatorArr("Customer", 2, 15)),
      TeamLeaderId: new FormControl(''),
      DevelopHours: new FormControl('', validate.createValidatorArr("DevelopHours", 2, 15)),
      QAHours: new FormControl('', validate.createValidatorArr("QAHours", 2, 15)),
      UiUxHours: new FormControl('', validate.createValidatorArr("UiUxHours", 2, 15)),
      StartDate: new FormControl(''),
      EndDate: new FormControl(''),
    };
    this.addProjectGroup = new FormGroup(formGroupConfig, validate.createValidatorDate);
  }
  ngOnInit() {
    this.managerService.getAllManagers().subscribe(
      res => {
        res.forEach(p => {
          if (p.JobId == 2) {
            this.teamLeader.push(p);
          }
        });
      })
    this.managerService.getAllWorkers().subscribe(
      res => {
        this.workers = res;
      }
    )
  }

  get f() { return this.addProjectGroup.controls; }

  onSubmit() {
   this.idTeam = this.teamLeader.find(p => p.Id == this.addProjectGroup.value["TeamLeaderId"]);
   this.addProjectGroup.value["TeamLeaderId"] = this.idTeam["Id"];
    this.managerService.addProject(this.addProjectGroup.value)
      .subscribe(project => {
        if (project == null) {
          //   localStorage.setItem('currentProject', JSON.stringify(project));
          this.router.navigate(['taskManagers/home']);
       this.managerService.addWorkersToProject(this.workersToAdd,this.addProjectGroup.value["Name"]).subscribe(res=> { }) 
        }
        else {
          this.router.navigate(['taskManagers/login'])
        }
      });

     
  }
  onChange(teamLeaderId) {
    this.workersToSelect = [];
    this.workers.forEach(
      w => {
        if (w.ManagerId != teamLeaderId.slice(3, teamLeaderId.Length) && w.JobId > 2)
          this.workersToSelect.push(w);
      });

  }
  addWorker(worker) {
    //console.log(this.workersToSelect);
    //console.log(worker);
    var w = this.workersToSelect.find(w => w.Name == worker)
    this.workersToAdd.push(w);
    var index = this.workersToSelect.indexOf(w);
    console.log(index);
    this.workersToSelect.splice(index, 1);
    console.log(this.workersToSelect);


  }
  removeWorker(worker) {
    var w = this.workersToAdd.find(w => w.Name == worker)
    this.workersToSelect.push(w);
    var index = this.workersToAdd.indexOf(w);
    this.workersToAdd.splice(index, 1);
  }
}
