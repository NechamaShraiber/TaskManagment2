import { Component, OnInit, Input } from '@angular/core';
import * as CanvasJS from '../../../canvasjs.min.js';
import { WorkerService } from '../../shared/service/worker.service.js';
//import {} from '../../../../'
@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  @Input()
  private projects: any[];
  projectDeatails = new Array();
  projectDeatails2 = new Array();
  chart: any;
  constructor(private workerService: WorkerService) {
    this.workerService.subjectUpdateChart.subscribe(
      {
        //dont work
        next: () => alert("1")
      });
  }

  ngOnInit() {
    this.creatChart();
  }
  creatChart() {
    for (let index = 0; index < this.projects.length; index++) {
      var r = this.projects[index].Hours;
      this.projectDeatails.push({
        y: this.projects[index].AllocatedHours, label: this.projects[index].Name
      })
      var t = this.projects[index].Hours.split(":");
      this.projectDeatails2.push({
        y: parseInt(t[0]) + (parseInt(t[1]) / 100), label: this.projects[index].Name
      })
    };
    this.chart = new CanvasJS.Chart("chartContainer", {
      animationEnabled: true,
      exportEnabled: true,

      title: {
        text: "project hours"
      },
      data: [{
        type: "column",
        dataPoints: this.projectDeatails,
      color:"#b498e6",

        name: "allocated hours",
        showInLegend: true,
      },
      {
        type: "column",
        dataPoints: this.projectDeatails2,
        name: "worked hours",
        color:"#758ee6",
        showInLegend: true,

      }],

    });

    this.chart.render();
  }

}
