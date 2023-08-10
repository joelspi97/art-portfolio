import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Medium } from '../models/Medium';

@Injectable({
  providedIn: 'root'
})
export class MediumService {
  private baseUrl: string = environment.baseUrl;

  private constructor(private http: HttpClient) { }

  public getMediums(): Observable<Medium[]> {
    return this.http.get<Medium[]>(this.baseUrl + 'mediums');
  }
}
