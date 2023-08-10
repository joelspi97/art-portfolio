import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArtPiece } from 'src/app/models/ArtPiece';
import { ArtPieceService } from 'src/app/services/art-piece.service';

@Component({
  selector: 'app-image-detail',
  templateUrl: './image-detail.component.html',
  styleUrls: ['./image-detail.component.scss']
})
export class ImageDetailComponent implements OnInit {
  public selectedArtPiece: ArtPiece | null | undefined = null;

  constructor(
    private artPieceService: ArtPieceService, 
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.artPieceService.currentArtPieces$.subscribe({
      next: (currentArtPieces: ArtPiece[] | null): void => {
        const foundArtPiece = currentArtPieces?.find(artPiece => artPiece.id == parseInt(this.route.snapshot.paramMap.get('id')!));
        
        if (foundArtPiece) {
          this.selectedArtPiece = foundArtPiece;
        } else {
          this.router.navigateByUrl('/page-not-found');
        }
      }
    });
  }

  ngOnInit(): void {
    
  }
}
