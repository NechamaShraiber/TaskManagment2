import { Component, OnInit } from '@angular/core';
import { WorkerService } from '../../shared/service/worker.service';
import { Route, Router } from '../../../../node_modules/@angular/router';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { SendMsgComponent } from '../send-msg/send-msg.component';
import { Worker } from '../../shared/models/worker';
import { timeout } from '../../../../node_modules/@types/q';
import { formatDate } from '@angular/common';
import { getAttrsForDirectiveMatching } from '../../../../node_modules/@angular/compiler/src/render3/view/util';


@Component({
  selector: 'app-home-worker',
  templateUrl: './home-worker.component.html',
  styleUrls: ['./home-worker.component.css']
})
export class HomeWorkerComponent implements OnInit {
  today: any;
 
  projects: any[];
<<<<<<< HEAD
=======
  names:string[];
>>>>>>> 2b3f2992ab1bba31092c3570a7b2e666776ff193
  currentWorker: Worker
 

  constructor(private workerService: WorkerService, private router: Router, private dialogService: DialogService) {

  }
  ngOnInit() {

    this.today = Date.now();
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.workerService.getProject(this.currentWorker.Id).subscribe(res => {
      this.projects = res;
<<<<<<< HEAD
=======
      this.names=this.projects.filter(p=>p["WorkerName"]);
console.log(this.names)
var groupByName = {};

this.names.forEach(function (a) {
    groupByName [a] = groupByName [a] || [];
    groupByName [a].push(a);
});
console.log(this.names)
>>>>>>> 2b3f2992ab1bba31092c3570a7b2e666776ff193
    });

  }

  send() {
    let disposable = this.dialogService.addDialog(SendMsgComponent, {
    })
      .subscribe((isConfirmed) => {
        //pass nr0504190  noreplytaskmanagers@gmail.com
        if (isConfirmed) {
          this.workerService.sendMsg().subscribe(res => {
            if (!res)
              alert('The email sent successfuly');
          })
        }
        else {
        }
      });
    setTimeout(() => {
      disposable.unsubscribe();
    }, 1000000);
  }
  // cli(e) {

  //  this.updateHours();
  //  }

 
}

