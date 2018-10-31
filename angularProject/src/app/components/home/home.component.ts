import { Component, OnInit } from '@angular/core';
import { Worker } from '../../shared/models/worker';
import { Router } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentWorker: Worker
  constructor(private router: Router) {
  }
  id: number
  ngOnInit() {
    this.currentWorker = JSON.parse(localStorage.getItem('currentUser'));
    this.id = this.currentWorker.JobId;
    if (this.id >= 3) {
      this.router.navigate(['taskManagers/homeWorkerComponent']);
    }
  }
}

