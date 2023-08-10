import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ArtPiece } from '../models/ArtPiece';
import { ArtPieceRequestDTO } from '../models/ArtPieceRequestDTO';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArtPieceService {
  private baseUrl: string = environment.baseUrl;
  private artPiecesSource = new BehaviorSubject<ArtPiece[] | null>(null);
  public currentArtPieces$: Observable<ArtPiece[] | null> = this.artPiecesSource.asObservable();

  private constructor(private http: HttpClient) {
    this.getAllArtPieces().pipe(take(1)).subscribe();
  } 

  public uploadArtPiece(newArtPiece: ArtPieceRequestDTO): Observable<ArtPiece> {
    return this.http.post<ArtPiece>(this.baseUrl + 'ArtPieces', newArtPiece);
  }

  private getAllArtPieces(): Observable<void> {
    return this.http.get<ArtPiece[]>(this.baseUrl + 'ArtPieces').pipe(
      map((artPieces: ArtPiece[]) => {
        this.artPiecesSource.next(artPieces);
      })
    );
  }
}
