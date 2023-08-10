import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImageGalleryComponent } from './components/image-gallery/image-gallery.component';
import { WrittenGalleryComponent } from './components/written-gallery/written-gallery.component';
import { ArtistIntroComponent } from './components/artist-intro/artist-intro.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ImageFormComponent } from './components/image-form/image-form.component';
import { WrittenFormComponent } from './components/written-form/written-form.component';
import { ImageDetailComponent } from './components/image-detail/image-detail.component';
import { WrittenDetailComponent } from './components/written-detail/written-detail.component';

const routes: Routes = [
  { path: '', component: ArtistIntroComponent },
  { path: 'galeria-imagenes/:medium', component: ImageGalleryComponent },
  { path: 'galeria-escritos/:type', component: WrittenGalleryComponent },
  { path: 'formulario-imagenes', component: ImageFormComponent },
  { path: 'formulario-escritos', component: WrittenFormComponent },
  { path: 'detalle-imagen/:id', component: ImageDetailComponent },
  { path: 'detalle-escrito/:id', component: WrittenDetailComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
