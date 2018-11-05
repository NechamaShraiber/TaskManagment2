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
                    if (state.url == "/taskManagers/home/usersManagers" || state.url == "/taskManagers/home/addProject" || state.url == "/taskManagers/home/Addworker")
                        return true;
                    break;
                }
            case 2: {
                if (state.url == "/taskManagers/home/teamLeaderProjects" || state.url == "/taskManagers/home/teamLeaderWorkers" || state.url == "/taskManagers/home/projectDeatails")
                    return true;
                break;
            }
            case 3: {
                if (state.url == "/taskManagers/homeWorkerComponent" || state.url == "/taskManagers/WorkerDeatails")
                    return true;
                break;
            } 
            case 4: {
                if (state.url == "/taskManagers/homeWorkerComponent" || state.url == "/taskManagers/WorkerDeatails")
                    return true;
                break;
            }
            case 5: {
                if (state.url == "/taskManagers/homeWorkerComponent" || state.url == "/taskManagers/WorkerDeatails")
                    return true;
                break;
            }
        }
        this.router.navigate(['/login']);
        return false;
    }
}