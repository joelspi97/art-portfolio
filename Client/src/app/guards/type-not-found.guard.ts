import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { TypeService } from '../services/type.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TypeNotFoundGuard implements CanActivate {
  constructor(private typeService: TypeService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
    return this.typeService.types$.pipe(
      map(types => {
        if (!types) return false;

        if (types.some(type => type.name === route.paramMap.get('type'))) return true;

        this.router.navigateByUrl('page-not-found');
        return false;
      })
    );
  }
}
