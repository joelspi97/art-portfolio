// This module contains 3rd parties libraries 

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDatepickerModule.forRoot()
  ],
  exports: [
    BsDatepickerModule
  ]
})
export class SharedModule { }
