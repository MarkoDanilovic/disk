import {Component, Injectable, OnInit, Output} from '@angular/core';
import {NgForm} from "@angular/forms";
import {HttpClient, HttpInterceptor} from "@angular/common/http";
import {UserLogin} from "../../shared/models/userLogin";
import {Cart} from "../../shared/models/cart";
import {MatDialog} from "@angular/material/dialog";
import {LoggingService} from "../logging.service";

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.scss']
})
@Injectable()
export class LoginDialogComponent implements OnInit {

  invalidLogin: boolean;

  userjson = '';




  public user : UserLogin = new UserLogin()

  constructor(private httpClient: HttpClient, private mat: MatDialog, private logService: LoggingService) { }

  ngOnInit(): void {
  }


  login(form: NgForm){

    this.user.email = form.value.email
    this.user.password = form.value.password

    this.logService.login(this.user)

  }


}
