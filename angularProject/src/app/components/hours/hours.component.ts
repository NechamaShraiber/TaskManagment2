import { Component, Input } from '@angular/core';
import { WorkerService } from '../../shared/service/worker.service';
import { formatDate } from '../../../../node_modules/@angular/common';
import { Button } from '../../../../node_modules/@types/selenium-webdriver';

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
  time: any;
  timer: any;
  startTask: any;
  sumTime: any;
  workedTime: any;
  hours: number;
  minute: number;
  IsmoreThenAllocatedHours: boolean = false;
  constructor(private workerService: WorkerService) {
    this.timer = () => {
      this.t = Math.floor(new Date().getTime()- this.startTask.getTime());
      this.hours = eval(this.workedTime[0] + "+" + Math.floor((this.t % 86400000) / 3600000));
      this.minute = eval(this.workedTime[1] + "+" + Math.round(((this.t % 86400000) % 3600000) / 60000));
      if (this.minute > 59) {
        this.hours++;
        this.minute -= 60;
      }
      if (Number(this.hours + "." + this.minute) >= Number(this.hour["AllocatedHours"]) && !this.IsmoreThenAllocatedHours) {
        clearInterval(this.timer);
        if (confirm("you work more them allocated hours Are you whant continue?")) {
          this.IsmoreThenAllocatedHours = true;
          setInterval(this.timer, 1000);

        }
        else {
          this.updateHours();
        }
      }

    }
  }

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
      this.workedTime = this.hour["Hours"].split(":");
      setInterval(this.timer, 1000);

    }
    else {
      //  this.btnValue = "start";
      clearInterval(this.timer);
      this.startTask = null;
      this.sumTime = this.t;
      this.IsmoreThenAllocatedHours = false;
      this.t = null;

    }
    this.workerService.updateStartHour(this.time, this.currectProject.Id, this.isStart).subscribe(
      res => {
        if (!this.isStart) {
          this.workerService.projectStart = null;
          this.hour["Hours"] = this.hours + ":" + this.minute;
        }
        this.isStart = !this.isStart;
      })
  }

}
