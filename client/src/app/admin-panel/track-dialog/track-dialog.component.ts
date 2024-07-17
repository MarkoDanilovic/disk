import {Component, Inject, Input, OnInit} from '@angular/core';
import {PanelService} from "../panel.service";
import {IProducer} from "../../shared/models/producer";
import {IMedium} from "../../shared/models/medium";
import {ILabel} from "../../shared/models/label";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-track-dialog',
  templateUrl: './track-dialog.component.html',
  styleUrls: ['./track-dialog.component.scss']
})
export class TrackDialogComponent implements OnInit {

  trackName = ''
  price : number;
  duration : number;
  genreId: number;
  producerId: number;
  labelId: number;
  mediumId: number;
  quantity: number;
  publishDate = ''


  constructor(private panelService: PanelService,@Inject(MAT_DIALOG_DATA)public data: any) { }

  ngOnInit(): void {
  //console.log(this.data)
  }


  insertTrack(form: NgForm){
    this.panelService.insertTrack(
      this.trackName = form.value.trackname,
      this.price = form.value.price,
      this.duration = form.value.duration,
      this.genreId = form.value.genreId,
      this.producerId = form.value.producerId,
      this.labelId = form.value.labelId,
      this.mediumId = form.value.mediumId,
      this.publishDate = form.value.publishDate,
      this.quantity = form.value.quantity,
      )
    console.log(this.trackName)
  }
}
