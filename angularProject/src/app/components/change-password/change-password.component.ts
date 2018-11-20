import { Component, OnInit } from '@angular/core';
import { sha256 } from '../../../../node_modules/js-sha256';
import { validate } from '../../shared/validate';
import { FormBuilder, FormGroup } from '../../../../node_modules/@angular/forms';
import { Router } from '../../../../node_modules/@angular/router';
import { GlobalService } from '../../shared/service/global.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent {
  loginFormGroup: FormGroup;
  isExistUser: boolean = true;
  //allow access 'Object' type via interpolation
  objectHolder: typeof Object = Object;

  //----------------CONSTRUCTOR------------------

  constructor(private formBuilder: FormBuilder, private router: Router, private globalService: GlobalService) {
    this.loginFormGroup = this.formBuilder.group({
      userName: ['', validate.createValidatorArr("userName", 2, 10)],
      lastPass: ['', validate.createValidatorArr("lastPass", 6, 10)],
      newPass: ['', validate.createValidatorArr("newPass", 6, 10)],
      confirmPass: ['', validate.createValidatorArr("confirmPass", 6, 10)],

    });
  }

  //----------------METHODS-------------------

 async onSubmit() {
    const lastPass = await sha256(this.lastPass.value);
    const newPass = await sha256(this.newPass.value);
    const confirmPass = await sha256(this.confirmPass.value);
if(newPass!=confirmPass)
alert("The new pass is not correct");
    this.globalService.changePassword(this.userName.value,lastPass,newPass)
      .subscribe(worker => { 
        if(worker){
          try{
          localStorage.setItem('currentUser', JSON.stringify(worker));
          this.router.navigate(['taskManagers/home']);
          }
          catch(Error){
            console.log(worker+"ERROR");

          }
        }
          else{
            console.log("ERRORRRRRRRRRRRRRRRRR");
            alert("One or more data is not correct");
            this.router.navigate(['taskManagers/login']);
          }
          localStorage.setItem('currentUser', JSON.stringify(worker));
          this.router.navigate(['taskManagers/home']);
      },err=>{
        this.isExistUser=false;
            this.router.navigate(['taskManagers/login']);
      })
  }


  //----------------GETTERS-------------------

  //getters of the form group controls

  get userName() {
    return this.loginFormGroup.controls["userName"];
  }
  get lastPass() {
    return this.loginFormGroup.controls["lastPass"];
  }
  get newPass() {
    return this.loginFormGroup.controls["newPass"];
  }
  get confirmPass() {
    return this.loginFormGroup.controls["confirmPass"];
  }
}
