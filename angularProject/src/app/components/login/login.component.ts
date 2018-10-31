import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { WorkerService } from '../../shared/service/worker.service';
import { validate } from '../../shared/validate';
// import { Global, AuthenticationService, createValidatorArr } from '../../imports';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //----------------PROPERTIRS-------------------

  loginFormGroup: FormGroup;
  isExistUser: boolean = true;

  //allow access 'Object' type via interpolation
  objectHolder: typeof Object = Object;

  //----------------CONSTRUCTOR------------------

  constructor(private formBuilder: FormBuilder, private router: Router, private workerService: WorkerService) {
    this.loginFormGroup = this.formBuilder.group({
      userName: ['', validate.createValidatorArr("userName", 2, 10)],
      password: ['', validate.createValidatorArr("password", 6, 10)],
    });
  }

  //----------------METHODS-------------------

  onSubmit() {
    this.workerService.login(this.userName.value, this.password.value)
      .subscribe(worker => {
        if (worker != null) {
          localStorage.setItem('currentUser', JSON.stringify(worker));
          this.router.navigate(['taskManagers/home']);
        }
        else {
          this.isExistUser = false;
          this.router.navigate(['taskManagers/login'])
        }
      });
  }

  //----------------GETTERS-------------------

  //getters of the form group controls

  get userName() {
    return this.loginFormGroup.controls["userName"];
  }
  get password() {
    return this.loginFormGroup.controls["password"];
  }
}