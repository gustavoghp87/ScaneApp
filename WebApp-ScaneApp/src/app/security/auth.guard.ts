import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiauthService } from '../services/apiauth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    
    constructor(private router: Router, private apiauthService: ApiauthService) {
    }
    
    canActivate(route2: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const user = this.apiauthService.GetUserData;
        if (user) return true;
        this.router.navigate(['/login'])
        return false;
    }

}

