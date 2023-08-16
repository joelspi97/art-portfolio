import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ArtPiece } from '../models/ArtPiece';
import { ArtPieceRequestDTO } from '../models/ArtPieceRequestDTO';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArtPieceService {
  private baseUrl: string = environment.baseUrl;
  private currentArtPiecesSource = new BehaviorSubject<ArtPiece[] | null>(null);
  public currentArtPieces$ = this.currentArtPiecesSource.asObservable();

  private constructor(private http: HttpClient) { } 

  public uploadArtPiece(newArtPiece: ArtPieceRequestDTO): Observable<ArtPiece> {
    return this.http.post<ArtPiece>(this.baseUrl + 'ArtPieces', newArtPiece);
  }

  public getAllArtPieces(artPieceType: string): Observable<void> {
    return this.http.get<ArtPiece[]>(`${ this.baseUrl }ArtPieces?type=${ artPieceType }`).pipe(
      map((response: ArtPiece[]) => {
        const artPieces = response;
        this.currentArtPiecesSource.next(artPieces);
      })
    );
  }
}
