import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {PanelService} from "../panel.service";

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent implements OnInit {

  name = ''
  lastname = ''
  email = ''
  telephone = ''
  address = ''
  password= ''
  city= ''
  country= ''


  constructor(private panelService: PanelService) { }

  ngOnInit(): void {
  }

  insertUser(userform: NgForm) {
    console.log(userform)
    this.panelService.insertUser(

      this.name = userform.value.name,
      this.lastname = userform.value.lastname,
      this.email = userform.value.email,
      this.password = userform.value.password,
      this.address = userform.value.address,
      this.country = userform.value.country,
      this.city = userform.value.city,
      this.telephone = userform.value.telephone
      )
  }
}
