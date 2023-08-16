import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Medium } from '../models/Medium';

@Injectable({
  providedIn: 'root'
})
export class MediumService {
  private baseUrl: string = environment.baseUrl;
  private mediumsSource = new BehaviorSubject<Medium[] | null>(null);
  public mediums$ = this.mediumsSource.asObservable();

  private constructor(private http: HttpClient) { }

  public getMediums(): void {
    if (this.mediumsSource.value === null) {
      this.fetchMediumsFromApi();
    }
  }

  private fetchMediumsFromApi(): void {
    this.http.get<Medium[]>(this.baseUrl + 'mediums').subscribe({
      next: types => {
        this.mediumsSource.next(types);
      },
      error: error => {
        console.error('Error fetching mediums:', error);
        this.mediumsSource.next([]); 
      }
    });
  }
}
