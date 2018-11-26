import { Component, Input } from '@angular/core';
import { WorkerService } from '../../shared/service/worker.service';
import { formatDate } from '../../../../node_modules/@angular/common';

@Component({
  selector: 'app-hours',
  templateUrl: './hours.component.html',
  styleUrls: ['../project/project.component.css', './hours.component.css']
})
export class HoursComponent {
  @Input()
  private hour: any;
  @Input()
  private isProject: boolean = false;
  currectProject: any;
  isStart: boolean = true;
  t: any;
  timer;
  time: any;
  startTask: any;
  sumTime: any;
  constructor(private workerService: WorkerService) { }

  updateHours() {

    if (this.workerService.projectStart != null && this.workerService.projectStart != this.hour) {
      alert("you must end project " + this.workerService.projectStart.Name);
      return;

    }


    this.time = formatDate(new Date(), 'yyyy/MM/dd hh:mm:ss', 'en');
    if (this.isStart) {
      this.currectProject = this.hour;
      this.workerService.projectStart = this.hour;
      this.startTask = new Date();

      this.timer = setInterval(() => {
        var ttt=new Date().getTime();
        this.t="00";
        this.t +=  ttt-this.startTask.getTime() ;



      }, 1000);
    }
    else {
      //  this.btnValue = "start";
      clearInterval(this.timer);
      this.startTask = null;
      this.sumTime = this.t;

      this.t = null;

    }
    this.workerService.updateStartHour(this.time, this.currectProject.Id, this.isStart).subscribe(
      res => {
        if (!this.isStart) {
          this.workerService.projectStart = null;
          this.workerService.subjectUpdateChart.next();
          var x1 = this.hour["Hours"].split(":");
          var hours = eval(x1[0] + "+" + Math.floor((this.sumTime % 86400000) / 3600000));
          var minute = eval(x1[1] + "+" + Math.round(((this.sumTime % 86400000) % 3600000) / 60000));
          if (minute > 59) {
            hours++;
            minute -= 60;
          }
          this.hour["Hours"] = hours + ":" + eval(x1[1] + "+" + minute);
        }



        this.isStart = !this.isStart;

      })
  }

}
