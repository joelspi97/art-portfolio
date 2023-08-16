import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ArtPieceType } from '../models/ArtPieceType';

@Injectable({
  providedIn: 'root'
})
export class TypeService {
  private baseUrl: string = environment.baseUrl;
  private typesSource = new BehaviorSubject<ArtPieceType[] | null>(null);
  public types$ = this.typesSource.asObservable();

  constructor(private http: HttpClient) { }

  public getTypes(): void {
    if (this.typesSource.value === null) {
      this.fetchTypesFromApi();
    }
  }

  private fetchTypesFromApi(): void {
    this.http.get<ArtPieceType[]>(this.baseUrl + 'ArtPieceTypes').subscribe({
      next: types => {
        this.typesSource.next(types);
      },
      error: error => {
        console.error('Error fetching types:', error);
        this.typesSource.next([]); 
      }
    });
  }
}
