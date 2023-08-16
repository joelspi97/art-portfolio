import { Injectable } from '@angular/core';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TypeService } from '../services/type.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TypeNotFoundGuard implements CanActivate {
  constructor(private typeService: TypeService, private router: Router, private route: ActivatedRoute) { }

  canActivate(): Observable<boolean> {
    let artPieceType: string; 

    this.route.paramMap.subscribe(params => {
      artPieceType = params.get('type') || '';
    })
    
    return this.typeService.types$.pipe(
      map(types => {
        if (types) {
          if (types.some(type => type.name === artPieceType)) {
            return true;
          } else {
            this.router.navigateByUrl('page-not-found');
          }
        }

        return false;
      })
    );
  }
}
