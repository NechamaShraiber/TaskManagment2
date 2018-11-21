import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { WorkerService } from './service/worker.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private workerService: WorkerService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        switch (this.workerService.idJob) {
            case 1:
                {                    
                    if (state.url == "/taskManagers/home" || state.url == "/taskManagers/home/addProject" || state.url == "/taskManagers/home/reports" || state.url == "/taskManagers/home/AddWorker")
                        return true;
                    break;
                }
            case 2: {
                if (state.url == "/taskManagers/home/teamLeaderProjects" || state.url == "/taskManagers/home/teamLeaderWorkers" || state.url == "/taskManagers/home/projectDeatails")
                    return true;
                break;
            }
            default: {
                if (state.url == "/taskManagers/home/homeWorker" || state.url == "/taskManagers/home/workerChart")
                    return true;
                break;
            } 
            // case 4: {
            //     if (state.url == "/taskManagers/home/homeWorker" || state.url == "/taskManagers/home/workerChart")
            //         return true;
            //     break;
            // }
            // case 5: {
            //     if (state.url == "/taskManagers/home/homeWorker" || state.url == "/taskManagers/home/workerChart")

            //         return true;
            //     break;
            // }
        }
        this.router.navigate(['/login']);
        return false;
    }
}