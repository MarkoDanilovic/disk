import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminPanelRoutingModule } from './admin-panel-routing.module';
import { AdminComponent } from './admin/admin.component';
import { GenreDialogComponent } from './genre-dialog/genre-dialog.component';
import {FormsModule} from "@angular/forms";
import { MediumDialogComponent } from './medium-dialog/medium-dialog.component';
import { TrackDialogComponent } from './track-dialog/track-dialog.component';
import { LabelDialogComponent } from './label-dialog/label-dialog.component';
import { ProducerDialogComponent } from './producer-dialog/producer-dialog.component';
import { UserDialogComponent } from './user-dialog/user-dialog.component';
import {MatTableModule} from "@angular/material/table";
import {MatButtonModule} from "@angular/material/button";


@NgModule({
  declarations: [
    AdminComponent,
    GenreDialogComponent,
    MediumDialogComponent,
    TrackDialogComponent,
    LabelDialogComponent,
    ProducerDialogComponent,
    UserDialogComponent
  ],
  imports: [
    CommonModule,
    AdminPanelRoutingModule,
    FormsModule,
    MatTableModule,
    MatButtonModule
  ]
})
export class AdminPanelModule { }
