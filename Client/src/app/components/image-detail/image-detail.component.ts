import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { ArtPiece } from 'src/app/models/ArtPiece';
import { ArtPieceService } from 'src/app/services/art-piece.service';

@Component({
  selector: 'app-image-detail',
  templateUrl: './image-detail.component.html',
  styleUrls: ['./image-detail.component.scss']
})
export class ImageDetailComponent implements OnInit {
  public selectedArtPiece: ArtPiece | null = null;

  constructor(private artPieceService: ArtPieceService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: params => {
        if (params.get('id')) {
          this.artPieceService.getArtPieceById(parseInt(params.get('id') as string)).pipe(take(1)).subscribe({
            next: artPiece => this.selectedArtPiece = artPiece
          });
        }
      }
    });
  }

  public deleteArtPiece(): void {
    if (this.selectedArtPiece && confirm('¿Estás seguro que querés borrar esta obra?')) {
      this.artPieceService.deleteArtPieceById(this.selectedArtPiece.id).pipe(take(1)).subscribe({
        next: () => this.router.navigateByUrl(`/galeria-imagenes/${ this.selectedArtPiece!.type.name }`)
      });
    }
  } 
}
