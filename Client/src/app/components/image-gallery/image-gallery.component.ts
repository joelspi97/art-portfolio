import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtPiece } from 'src/app/models/ArtPiece';
import { ArtPieceService } from 'src/app/services/art-piece.service';

@Component({
  selector: 'app-image-gallery',
  templateUrl: './image-gallery.component.html',
  styleUrls: ['./image-gallery.component.scss']
})
export class ImageGalleryComponent implements OnInit {
  public artPieces: ArtPiece[] | null = null;
  public artType: string = '';

  constructor(private artPieceService: ArtPieceService, private route: ActivatedRoute) {
    this.artPieceService.currentArtPieces$.subscribe({
      next: (currentArtPieces: ArtPiece[] | null): void => { this.artPieces = currentArtPieces }
    })
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.artType = params.get('type') || '';  

      if (this.artPieces) {
        this.artPieces = this.artPieces.filter(artPiece => artPiece.type.name === this.artType);
      }
    });
  }
}
