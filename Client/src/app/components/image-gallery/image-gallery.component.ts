import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtPiece } from 'src/app/models/ArtPiece';
import { ArtPieceType } from 'src/app/models/ArtPieceType';
import { ArtPieceService } from 'src/app/services/art-piece.service';

@Component({
  selector: 'app-image-gallery',
  templateUrl: './image-gallery.component.html',
  styleUrls: ['./image-gallery.component.scss']
})
export class ImageGalleryComponent implements OnInit {
  public artPieces: ArtPiece[] | null = null;

  constructor(public artPieceService: ArtPieceService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let artPieceType: string = params.get('type') || '';
      this.artPieceService.getAllArtPieces(artPieceType).subscribe();
    });
  }
}
