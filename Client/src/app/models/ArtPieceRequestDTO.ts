import { Medium } from "./Medium";

export interface ArtPieceRequestDTO {
  title: string;
  description?: string;
  createdAt: Date;
  mediums: Medium[];
}