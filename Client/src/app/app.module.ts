import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from './modules/shared.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ImageGalleryComponent } from './components/image-gallery/image-gallery.component';
import { WrittenGalleryComponent } from './components/written-gallery/written-gallery.component';
import { ArtistIntroComponent } from './components/artist-intro/artist-intro.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ImageFormComponent } from './components/image-form/image-form.component';
import { WrittenFormComponent } from './components/written-form/written-form.component';
import { ImageDetailComponent } from './components/image-detail/image-detail.component';
import { WrittenDetailComponent } from './components/written-detail/written-detail.component';
import { ImageUpdateFormComponent } from './components/image-update-form/image-update-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ImageGalleryComponent,
    WrittenGalleryComponent,
    ArtistIntroComponent,
    NotFoundComponent,
    ImageFormComponent,
    WrittenFormComponent,
    ImageDetailComponent,
    WrittenDetailComponent,
    ImageUpdateFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
