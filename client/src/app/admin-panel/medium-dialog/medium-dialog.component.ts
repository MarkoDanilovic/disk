import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {PanelService} from "../panel.service";

@Component({
  selector: 'app-medium-dialog',
  templateUrl: './medium-dialog.component.html',
  styleUrls: ['./medium-dialog.component.scss']
})
export class MediumDialogComponent implements OnInit {

  mediumName = ''

  constructor(private panelService: PanelService) { }

  ngOnInit(): void {
  }


  insertMedium(form: NgForm){
    this.panelService.insertMedium(this.mediumName = form.value.medium)
  }
}
