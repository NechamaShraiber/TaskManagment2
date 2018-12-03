import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Worker } from '../models/worker';
import { sha256 } from 'js-sha256';
import { GlobalService } from './global.service';
import * as XLSX from 'xlsx';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {
  workerToUpdate: Worker;
  idWorkerToDelete: any;
  isEdit: string = "Add";
  str:string;
  ids:number[];
  URLPHPUSERS: string = "http://localhost/TaskManagment/UIL/index.php"

  constructor(private http: HttpClient) {
    this.workerToUpdate = new Worker;
  }

  addProject(project): any {
    return this.http.post(GlobalService.path+"addProject/", JSON.parse(JSON.stringify(project)))
    //return this.http.post(this.URLPHPUSERS,data: JSON.parse(JSON.stringify(project)));

  }
  getAllManagers(): any {
   return this.http.get(this.URLPHPUSERS+"?funcation=getAllManagers");

  }
  
  addWorker(worker): any {
    worker.Password=sha256(worker.Password);
      return this.http.post(GlobalService.path+"addWorker/", JSON.parse(JSON.stringify(worker)))
}
  getAllWorkers(): any {
     return this.http.get(this.URLPHPUSERS+"?funcation=getAllWorkers");

  }
  deleteWorker() {
    return this.http.delete(GlobalService.path+"deleteWorker/" + this.idWorkerToDelete)
  }
  updateWorker(worker): any {
    worker.Id = this.workerToUpdate.Id;
    return this.http.put(GlobalService.path+"updateWorker/", JSON.parse(JSON.stringify(worker)))
 

  }
  addWorkersToProject(workers:Worker[],name):any{
    this.ids=[];
    workers.forEach(w => {
      this.ids.push(w.Id);
    });

    return this.http.post(GlobalService.path+"addWorkersToProject/"+name+"/", JSON.parse(JSON.stringify(this.ids)))

  }
 
  getPresence():any{
   //  return this.http.get(GlobalService.path+"getPresence");
     return this.http.get(this.URLPHPUSERS+"?funcation=getPresence");

  }
 static toExportFileName(excelFileName: string):string
  {
        return `${excelFileName}_export_${new Date().getTime()}.xlsx`;
      }
         
    public exportAsExcelFile(json: any[]): void {
    
        const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet( JSON.parse( JSON.stringify(json)));
        const workbook: XLSX.WorkBook = {Sheets: {'data': worksheet}, SheetNames: ['data']};
        XLSX.writeFile(workbook, ManagerService.toExportFileName("Excl"));
        const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
      } 

}

