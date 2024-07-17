import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {PanelService} from "../panel.service";

@Component({
  selector: 'app-producer-dialog',
  templateUrl: './producer-dialog.component.html',
  styleUrls: ['./producer-dialog.component.scss']
})
export class ProducerDialogComponent implements OnInit {

  name = ''
  surname = ''
  email =''
  birthday = ''
  artistName = ''
  country = ''



  constructor(private panelService : PanelService) { }

  ngOnInit(): void {
  }

  insertProducer(producerform: NgForm) {
    this.panelService.insertProducer(this.name = producerform.value.name,
      this.surname = producerform.value.surname,
      this.email = producerform.value.email,
      this.artistName = producerform.value.artistName,
      this.birthday = producerform.value.birthday,
      this.country = producerform.value.country
      )
  }
}
