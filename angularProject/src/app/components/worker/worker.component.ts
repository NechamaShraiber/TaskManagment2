import { Component, OnInit, Input } from '@angular/core';
import { Worker } from '../../shared/models/worker';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkerComponent implements OnInit {
@Input() 
worker:Worker;
  constructor() { }

  ngOnInit() {
    console.log(this.worker)
  }

}
