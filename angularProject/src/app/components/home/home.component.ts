import { Component, OnInit } from '@angular/core';
import { Worker } from '../../shared/models/worker';
import { Router } from '@angular/router';
import { WorkerService } from '../../shared/service/worker.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentWorker: Worker
  constructor(private router: Router,private workerService:WorkerService) {
  }
  //id: number
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.workerService.idJob = this.currentWorker.JobId;
    if (this.workerService.idJob >= 3) {
      this.router.navigate(['taskManagers/homeWorkerComponent']);
    }
  }
}

