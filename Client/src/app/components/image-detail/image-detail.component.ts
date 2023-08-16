import { Component, OnInit } from '@angular/core';
import { ArtPiece } from 'src/app/models/ArtPiece';

@Component({
  selector: 'app-image-detail',
  templateUrl: './image-detail.component.html',
  styleUrls: ['./image-detail.component.scss']
})
export class ImageDetailComponent implements OnInit {
  public selectedArtPiece: ArtPiece | null | undefined = null;

  constructor(
 
  ) { }

  ngOnInit(): void {
    
  }
}
