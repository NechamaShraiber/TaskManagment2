



import { Component, OnInit } from '@angular/core';
import { WorkerService } from '../../shared/service/worker.service';
import { Route, Router } from '../../../../node_modules/@angular/router';
import { DialogService } from '../../../../node_modules/ng2-bootstrap-modal';
import { SendMsgComponent } from '../send-msg/send-msg.component';
import { Time } from '../../../../node_modules/@angular/common';
@Component({
  selector: 'app-home-worker',
  templateUrl: './home-worker.component.html',
  styleUrls: ['./home-worker.component.css']
})
export class HomeWorkerComponent implements OnInit {
  today: any;
  startTask: any=new Date();
  endTask: any=new Date();
  projectList: any;
  id: number;
  currentWorker: Worker;
  currectProject: number;
  count: number=0;
  isStart: boolean = false;
  // x: NodeJS.Timer;
  
  constructor(private workerService: WorkerService, private router: Router, private dialogService: DialogService) { }
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.id = this.currentWorker["Id"];
    this.workerService.getProject(this.id).subscribe(res => {
      this.projectList = res;
    });
  }
  // x = setInterval(() => {
  //   this.today = Date.now();
  // }, 1000)

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
  cli(e) {
    this.currectProject = e;
  }
  // 
   updateHours() {
  //   if (!this.currectProject)
  //     alert("you must choose a project")
  //   else {
  //     this.count++;
  //     if (this.count == 1) {
  //      this.x= setInterval(() => {
  //         this.today =Date.now()
  //       }, 1000)
  //       this.startTask=Date.now();
  //       console.log(this.startTask);
  //       this.isStart = true;
  //     }
  //     if (this.count == 2) {
  //       clearInterval(this.x);
  //       this.endTask=new Date().getTime()
  //       console.log(this.endTask);
  //       this.count = 0;
  //     }
  // }

  }
}

