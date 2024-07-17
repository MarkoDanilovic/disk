import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {PanelService} from "../panel.service";

@Component({
  selector: 'app-label-dialog',
  templateUrl: './label-dialog.component.html',
  styleUrls: ['./label-dialog.component.scss']
})
export class LabelDialogComponent implements OnInit {

  labelName = ''
  country = ''
  email = ''

  constructor(private panelService: PanelService) { }

  ngOnInit(): void {
  }

  insertlabel(labelform: NgForm) {
    this.panelService.insertLabel(this.labelName = labelform.value.label,
      this.country = labelform.value.country, this.email = labelform.value.email)
  }
}
