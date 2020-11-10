import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { RouterModule } from '@angular/router';

import { ModalComponent } from './_modal/modal.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    NgxSpinnerModule,
    RouterModule
  ],
  declarations: [
    ModalComponent,
    PageNotFoundComponent
  ],
  exports: [
    ModalComponent,
    PageNotFoundComponent,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule,
    NgxSpinnerModule
  ]
})

export class SharedModule { }
