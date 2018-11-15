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
  startTask: any;
  time: any;
  projects: any[];
  currentWorker: Worker
  currectProject: any;
  isStart: boolean = true;
  btnValue: string = "start";
  t: any;
  timer;

  constructor(private workerService: WorkerService, private router: Router, private dialogService: DialogService) {

  }
  ngOnInit() {

    this.today = Date.now();
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.workerService.getProject(this.currentWorker.Id).subscribe(res => {
      this.projects = res;
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

  updateHours(e) {

    if (!this.isStart && this.currectProject != e) {
      alert("you must end project "+ this.currectProject.Name);
      return;

    }
 
      
    this.time = formatDate(new Date(), 'yyyy/MM/dd hh:mm:ss', 'en');
    if (this.isStart) {
      this.currectProject = e;
      this.startTask = new Date();
      this.btnValue = "end";
      this.timer = setInterval(() => {
        this.t = Math.abs(new Date().getTime() - this.startTask.getTime());



      }, 1000);
    }
    else {
      this.btnValue = "start";
      clearInterval(this.timer);
      this.startTask = null;
      this.t = null;


    }
    this.workerService.updateStartHour(this.time, this.currectProject.Id, this.isStart).subscribe(
      res => {
        if (!this.isStart) {
          this.workerService.getProject(this.currentWorker.Id).subscribe(res => {
            this.projects = res;
            this.workerService.subjectUpdateChart.next(this.projects);
          });


        }



        this.isStart = !this.isStart;

      })
  }

}

