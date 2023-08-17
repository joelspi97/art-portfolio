import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Medium } from 'src/app/models/Medium';
import { MediumService } from 'src/app/services/medium.service';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ArtPieceService } from 'src/app/services/art-piece.service';
import { take } from 'rxjs/operators';
import { ArtPiece } from 'src/app/models/ArtPiece';
import { ActivatedRoute, Router } from '@angular/router';
import { ArtPieceType } from 'src/app/models/ArtPieceType';
import { TypeService } from 'src/app/services/type.service';

@Component({
  selector: 'app-image-form',
  templateUrl: './image-form.component.html',
  styleUrls: ['./image-form.component.scss']
})
export class ImageFormComponent implements OnInit {
  public mediums: Medium[] = [];
  public types: ArtPieceType[] =[]; 
  public artPieceForm: FormGroup = new FormGroup({});
  public selectedArtPiece: ArtPiece | null = null;

  constructor(
    public typeService: TypeService,
    public mediumService: MediumService, 
    private artPieceService: ArtPieceService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.mediumService.getMediums();
    this.initializeForm();
    this.checkEditMode();
  }

  public handleSubmit(): void {
    const inputDate: Date = new Date(this.artPieceForm.controls['createdAt'].value);

    const year = inputDate.getFullYear();
    const month = String(inputDate.getMonth() + 1).padStart(2, '0');
    const day = String(inputDate.getDate()).padStart(2, '0');
    
    const formattedDate = `${year}-${month}-${day}`;
    
    this.artPieceForm.controls['createdAt'].setValue(formattedDate);

    if (this.selectedArtPiece) {
      this.artPieceService.updateArtPiece(this.artPieceForm.value, this.selectedArtPiece.id).pipe(take(1)).subscribe({
        next: (response: ArtPiece): void => { this.router.navigateByUrl(`detalle-imagen/${ response.id }`) },
        error: (error: HttpErrorResponse): void => console.error(error.message)
      });
    } else {
      this.artPieceService.uploadArtPiece(this.artPieceForm.value).pipe(take(1)).subscribe({
        next: (response: ArtPiece): void => { this.router.navigateByUrl(`detalle-imagen/${ response.id }`) },
        error: (error: HttpErrorResponse): void => console.error(error.message)
      });
    }

  }

  public onCheckboxChange(event: any): void {
    const selectedMediums = this.artPieceForm.controls['mediumIds'] as FormArray;
    
    if (event.target.checked) {
      selectedMediums.push(new FormControl(event.target.value));
    } else {
      const index = selectedMediums.controls.findIndex(x => x.value === event.target.value);
      selectedMediums.removeAt(index);
    }
  }

  public isMediumSelected(mediumId: number): boolean {
    if (this.selectedArtPiece) {
      return this.selectedArtPiece.mediums.some(medium => medium.id === mediumId);
    }

    return false;
  }

  private checkEditMode(): void {
    this.activatedRoute.queryParamMap.subscribe({
      next: params => { 
        if(params.get('id')) { 
          this.artPieceService.getArtPieceById(parseInt(params.get('id') as string)).pipe(take(1)).subscribe({
            next: artPiece => {
              this.selectedArtPiece = artPiece;

              this.artPieceForm.controls['title'].setValue(artPiece.title);
              this.artPieceForm.controls['description'].setValue(artPiece.description);
              this.artPieceForm.controls['typeId'].setValue(artPiece.type.id.toString());
              this.artPieceForm.controls['createdAt'].setValue(new Date(artPiece.createdAt));

              const artPieceMediumsIds: string[] = artPiece.mediums.map(medium => medium.id.toString());
              const selectedMediums = this.artPieceForm.controls['mediumIds'] as FormArray;
              for (let artPieceMediumsId of artPieceMediumsIds) {
                selectedMediums.push(new FormControl(artPieceMediumsId));
              }
            }
          });
        } 
      }
    });
  }

  private initializeForm(): void {
    this.artPieceForm = this.formBuilder.group({
      title: [ '', [ Validators.required, Validators.minLength(5), Validators.maxLength(40) ] ],
      description: [ '' ],
      createdAt: [ '', Validators.required ],
      typeId: [ '', Validators.required ],
      mediumIds: new FormArray([], Validators.required)
    });
  } 
}
