import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {RegisterUser} from "../../shared/models/registerUser";
import {LoggingService} from "../logging.service";

@Component({
  selector: 'app-register-dialog',
  templateUrl: './register-dialog.component.html',
  styleUrls: ['./register-dialog.component.scss']
})
export class RegisterDialogComponent implements OnInit {

  constructor(private service: LoggingService) { }

  public user : RegisterUser = new RegisterUser()

  ngOnInit(): void {
  }

  register(registerForm: NgForm) {
    this.user.name = registerForm.value.name
    this.user.lastname = registerForm.value.lastname
    this.user.email = registerForm.value.email
    this.user.password = registerForm.value.password
    this.user.city = registerForm.value.city
    this.user.country = registerForm.value.country
    this.user.telephone = registerForm.value.telephone
    this.user.address = registerForm.value.address
    this.service.registerUser(this.user);

    //console.log(this.user)
  }
}
