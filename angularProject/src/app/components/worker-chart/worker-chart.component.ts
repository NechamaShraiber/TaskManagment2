import { Component, OnInit } from '@angular/core';
import { WorkerService } from '../../shared/service/worker.service';
import { Worker } from '../../shared/models/worker';

@Component({
  selector: 'app-worker-chart',
  templateUrl: './worker-chart.component.html',
  styleUrls: ['./worker-chart.component.css']
})
export class WorkerChartComponent implements OnInit {
  projects: any[];
  names:string[];
  currentWorker: Worker;
 
  constructor(private workerService:WorkerService) { }

  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.workerService.getProject(this.currentWorker.Id).subscribe(res => {
      this.projects = res;
    });

  }

}
