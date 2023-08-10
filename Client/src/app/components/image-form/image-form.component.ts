import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Medium } from 'src/app/models/Medium';
import { MediumService } from 'src/app/services/medium.service';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ArtPieceService } from 'src/app/services/art-piece.service';
import { take } from 'rxjs/operators';
import { ArtPiece } from 'src/app/models/ArtPiece';
import { Router } from '@angular/router';

@Component({
  selector: 'app-image-form',
  templateUrl: './image-form.component.html',
  styleUrls: ['./image-form.component.scss']
})
export class ImageFormComponent implements OnInit {
  public mediums: Medium[] = [];
  public newArtPieceForm: FormGroup = new FormGroup({});

  constructor(
    private mediumService: MediumService, 
    private formBuilder: FormBuilder,
    private artPieceService: ArtPieceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getMediums();
    this.initializeForm();
  }

  public createArtPiece(): void {
    const inputDate: Date = new Date(this.newArtPieceForm.controls['createdAt'].value);

    const year = inputDate.getFullYear();
    const month = String(inputDate.getMonth() + 1).padStart(2, '0');
    const day = String(inputDate.getDate()).padStart(2, '0');
    
    const formattedDate = `${year}-${month}-${day}`;
    
    this.newArtPieceForm.controls['createdAt'].setValue(formattedDate);

    this.artPieceService.uploadArtPiece(this.newArtPieceForm.value).pipe(take(1)).subscribe({
      next: (response: ArtPiece): void => { this.router.navigateByUrl(`detalle-imagen/${ response.id }`) },
      error: (error: HttpErrorResponse): void => console.error(error.message)
    });
  }

  public onCheckboxChange(event: any): void {
    const selectedMediums = (this.newArtPieceForm.controls['mediumIds'] as FormArray);
    
    if (event.target.checked) {
      selectedMediums.push(new FormControl(event.target.value));
    } else {
      const index = selectedMediums.controls.findIndex(x => x.value === event.target.value);
      selectedMediums.removeAt(index);
    }
  }

  private initializeForm(): void {
    this.newArtPieceForm = this.formBuilder.group({
      title: [ '', [ Validators.required, Validators.minLength(5), Validators.maxLength(40) ] ],
      description: [ '' ],
      createdAt: [ '', Validators.required ],
      mediumIds: new FormArray([], Validators.required)
    });
  } 

  private getMediums(): void {
    this.mediumService.getMediums().subscribe({
      next: (response: Medium[]): void => { this.mediums = response; },
      error: (error: HttpErrorResponse): void => console.log(error.message)
    });
  }
}
