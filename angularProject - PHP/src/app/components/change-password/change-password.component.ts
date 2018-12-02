import { Component } from '@angular/core';
import { sha256 } from '../../../../node_modules/js-sha256';
import { validate } from '../../shared/validate';
import { FormBuilder, FormGroup } from '../../../../node_modules/@angular/forms';
import { Router } from '../../../../node_modules/@angular/router';
import { GlobalService } from '../../shared/service/global.service';
import { DialogComponent, DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
export interface ConfirmModel {
  title: string;
}
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent extends DialogComponent<ConfirmModel, boolean> implements ConfirmModel {
  password: FormGroup;
  isExistUser: boolean = true;
  objectHolder: typeof Object = Object;
  title: string;

  constructor(private formBuilder: FormBuilder, private router: Router, private globalService: GlobalService, dialogService: DialogService) {
    super(dialogService);
    this.password = this.formBuilder.group({
      userName: ['', validate.createValidatorArr("userName", 2, 10)],
      lastPass: ['', validate.createValidatorArr("lastPass", 6, 10)],
      newPass: ['', validate.createValidatorArr("newPass", 6, 10)],
      confirmPass: ['', validate.createValidatorArr("confirmPass", 6, 10)],
    });
  }
  
  async confirm() {
    const lastPass = await sha256(this.lastPass.value);
    const newPass = await sha256(this.newPass.value);
    const confirmPass = await sha256(this.confirmPass.value);
    if (newPass != confirmPass)
      alert("The new pass is not correct");
    else {
      this.globalService.updatePassword(this.userName.value, lastPass, newPass)
      .subscribe(worker => {
        alert("The password changed");
        this.router.navigate(['taskManagers/login']);
      }
        , err => {
          alert("Can not change the password");
          this.router.navigate(['taskManagers/login']);
        })
    }
    this.result = true;
    this.close();
  }

  get userName() {
    return this.password.controls["userName"];
  }
  get lastPass() {
    return this.password.controls["lastPass"];
  }
  get newPass() {
    return this.password.controls["newPass"];
  }
  get confirmPass() {
    return this.password.controls["confirmPass"];
  }
}
