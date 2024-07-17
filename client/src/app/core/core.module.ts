import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavBarComponent} from "./nav-bar/nav-bar.component";
import { RouterModule} from "@angular/router";
import { LoginDialogComponent } from './login-dialog/login-dialog.component';
import { MatDialogModule} from "@angular/material/dialog";
import {FormsModule} from "@angular/forms";
import { RegisterDialogComponent } from './register-dialog/register-dialog.component';



@NgModule({
  declarations: [NavBarComponent, LoginDialogComponent, RegisterDialogComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatDialogModule,
    FormsModule,

  ],
  exports: [NavBarComponent,LoginDialogComponent],
  providers: [
    LoginDialogComponent
  ]
})
export class CoreModule { }
