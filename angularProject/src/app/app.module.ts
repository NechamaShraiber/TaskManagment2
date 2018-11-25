import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './components/home/home.component';
import { Routes, RouterModule } from '@angular/router';
import { WorkerService } from './shared/service/worker.service';
import { AddProjectComponent } from './components/add-project/add-project.component';
import { ReportsComponent } from './components/reports/reports.component';
import { AddWorkerComponent } from './components/add-worker/add-worker.component';
import { DeleteWorkerComponent } from './components/delete-worker/delete-worker.component';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { EditWorkerComponent } from './components/edit-worker/edit-worker.component';
import { TeamLeaderProjectComponent } from './components/team-leader-project/team-leader-project.component';
import { TeamLeaderWorkersComponent } from './components/team-leader-workers/team-leader-workers.component';
import { ProjectComponent } from './components/project/project.component';
import { WorkerComponent } from './components/worker/worker.component';
import { ProjectDeatailsComponent } from './components/project-deatails/project-deatails.component';
import { HoursComponent } from './components/hours/hours.component';
import { WorkerDeatailsComponent } from './components/worker-deatails/worker-deatails.component';
import { SendMsgComponent } from './components/send-msg/send-msg.component';
import { HomeWorkerComponent } from './components/home-worker/home-worker.component';
import { ChartComponent } from './components/chart/chart.component';
import { AuthGuard } from '../app/shared/auth.guard';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import 'hammerjs';
import { WorkerChartComponent } from './components/worker-chart/worker-chart.component';
import {MatButtonModule, MatCheckboxModule, MatNativeDateModule,MatTreeModule,MatIconModule} from '@angular/material';
import 'hammerjs';
import {MatDatepickerModule,MatFormFieldModule,MatInputModule,MatSelectModule,MatTableModule,MatPaginatorModule} from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 


const globalPath: string = "http://localhost:59628/api/";
const routes: Routes = [
  { path: 'taskManagers/login', component: LoginComponent },
  { path: 'taskManagers/changePassword', component: ChangePasswordComponent },

  {
    path: 'taskManagers/home', component: HomeComponent, children: [
      { path: 'addProject', component: AddProjectComponent, canActivate: [AuthGuard] },
      { path: 'Addworker', component: AddWorkerComponent, canActivate: [AuthGuard] },
      { path: 'reports/:id', component: ReportsComponent  },
      { path: 'teamLeaderProjects', component: TeamLeaderProjectComponent, canActivate: [AuthGuard] },
      { path: 'teamLeaderWorkers', component: TeamLeaderWorkersComponent, canActivate: [AuthGuard] },
      { path: 'teamLeaderWorkers', component: TeamLeaderWorkersComponent, canActivate: [AuthGuard] },
      { path: 'homeWorker', component: HomeWorkerComponent, canActivate: [AuthGuard] },
      { path: 'workerChart', component: WorkerChartComponent, canActivate: [AuthGuard] },

    ]
  },
  //{ path: 'taskManagers/projectDeatails', component: ProjectDeatailsComponent },
  // { path: 'taskManagers/homeWorkerComponent', component: HomeWorkerComponent, canActivate: [AuthGuard] },
  // { path: 'taskManagers/WorkerDeatails', component: WorkerDeatailsComponent },
  { path: '**', component: LoginComponent },
  { path: '', component: LoginComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    AddProjectComponent,
    ReportsComponent,
    AddWorkerComponent,
    DeleteWorkerComponent,
    EditWorkerComponent,
    TeamLeaderProjectComponent,
    TeamLeaderWorkersComponent,
    ProjectComponent,
    WorkerComponent,
    ProjectDeatailsComponent,
    HoursComponent,
    WorkerDeatailsComponent,
    HomeWorkerComponent,
    SendMsgComponent,
    ChartComponent,
    ChangePasswordComponent,
    WorkerChartComponent,
    //HomeWorkerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    BootstrapModalModule.forRoot({ container: document.body }),
    [MatButtonModule, MatCheckboxModule],
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,MatNativeDateModule,BrowserAnimationsModule,MatTreeModule,MatIconModule,MatSelectModule,MatTableModule,MatPaginatorModule
  
  ],
  entryComponents: [
    DeleteWorkerComponent, EditWorkerComponent, SendMsgComponent, ProjectDeatailsComponent, WorkerDeatailsComponent, ChangePasswordComponent

  ],
  exports: [MatButtonModule, MatCheckboxModule],

  providers: [WorkerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
