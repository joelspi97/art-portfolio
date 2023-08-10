import { ArtPieceType } from "./ArtPieceType";
import { Medium } from "./Medium";

export interface ArtPiece {
  id: number;
  title: string;
  description?: string;
  createdAt: Date;
  mediums: Medium[];
  type: ArtPieceType;
}
