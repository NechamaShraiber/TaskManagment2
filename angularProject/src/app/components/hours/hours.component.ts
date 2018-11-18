import { Component, OnInit, Input } from '@angular/core';
import { WorkerService } from '../../shared/service/worker.service';
import { formatDate } from '../../../../node_modules/@angular/common';

@Component({
  selector: 'app-hours',
  templateUrl: './hours.component.html',
  styleUrls: ['../project/project.component.css','./hours.component.css']
})
export class HoursComponent implements OnInit {
  @Input()
private hour:any;
@Input()
private isProject:boolean=false;
currectProject: any;
isStart: boolean = true;
// btnValue: string = "start";
t: any;
timer;
time: any;
startTask: any;

  constructor(private workerService:WorkerService) { }

  ngOnInit() {
    console.log(this.hour)
  }
  updateHours() {

     if (this.workerService.projectStart!=null && this.workerService.projectStart!=this.hour) {
       alert("you must end project "+ this.workerService.projectStart.Name);
       return;

   }
 
      
    this.time = formatDate(new Date(), 'yyyy/MM/dd hh:mm:ss', 'en');
    if (this.isStart) {
      this.currectProject = this.hour;
      this.workerService.projectStart=this.hour;
      this.startTask = new Date();
     // this.btnValue = "end";
     
      this.timer = setInterval(() => {
        this.t = Math.abs(new Date().getTime() - this.startTask.getTime());



      }, 1000);
    }
    else {
    //  this.btnValue = "start";
      clearInterval(this.timer);
      this.startTask = null;
      this.t = null;


    }
    this.workerService.updateStartHour(this.time, this.currectProject.Id, this.isStart).subscribe(
      res => {
        if (!this.isStart) {
          this.workerService.projectStart=null;
          // this.workerService.getProject(this.currentWorker.Id).subscribe(res => {
          //   this.projects = res;
          //   this.workerService.subjectUpdateChart.next(this.projects);
          // });
          //   this.workerService.subjectUpdateChart.next(this.projects);
          //לעשות כאן חשבון
this.hour["Hours"]=23;

        }



        this.isStart = !this.isStart;

      })
  }

}
