import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ManagerService } from '../../shared/service/manager.service';
import { validate } from '../../shared/validate';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {
  
  addProjectGroup: FormGroup;
  //isExistUser: boolean = true;
  teamLeader :any;
  idTeam:number;
  //allow access 'Object' type via interpolation
  objectHolder: typeof Object = Object;
  constructor(private router: Router, private managerService: ManagerService) {
    let formGroupConfig = {
      Name: new FormControl('', validate.createValidatorArr("Name", 2, 25)),
      Customer: new FormControl( '', validate.createValidatorArr("Customer", 2, 15)),
      TeamLeaderId: new FormControl(''),
      DevelopHours: new FormControl('', validate.createValidatorArr("DevelopHours", 2, 15)), 
      QAHours:new FormControl( '', validate.createValidatorArr("QAHours", 2, 15)),
      UiUxHours:new FormControl('', validate.createValidatorArr("UiUxHours", 2, 15)),
      StartDate: new FormControl('', validate.createValidatorArr("StartDate", 2, 15)),
      EndDate: new FormControl('', validate.createValidatorArr("EndDate", 2, 15)),
    };
    this.addProjectGroup = new FormGroup(formGroupConfig);
  }

/* TeamLeaderId 

 Customer 

 DevelopHours 

 QAHours 

 UiUxHours 
 */

  ngOnInit(){
    this.managerService.getAllManagers().subscribe(
      res=>{
        this.teamLeader=res;
    })
  }
 
  get f() { return this.addProjectGroup.controls; }

  onSubmit() {
   this.idTeam=this.teamLeader.find(p=>p.Name==this.addProjectGroup.value["TeamLeaderId"]).Id;
   this.addProjectGroup.value["TeamLeaderId"]=this.idTeam;
    this.managerService.addProject(this.addProjectGroup.value)
       .subscribe(project => {
         if (project == null) {
           localStorage.setItem('currentProject', JSON.stringify(project));
           this.router.navigate(['taskManagers/home']);
         }
         else {
          // this.isExistUser = false;
           this.router.navigate(['taskManagers/login'])
         }
       });
  }
}