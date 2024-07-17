import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {PanelService} from "../panel.service";

@Component({
  selector: 'app-genre-dialog',
  templateUrl: './genre-dialog.component.html',
  styleUrls: ['./genre-dialog.component.scss']
})
export class GenreDialogComponent implements OnInit {

  constructor(private panelService: PanelService) { }

  genreName: String

  ngOnInit(): void {
  }


  insertGenre(form: NgForm){
    this.panelService.insertGenre(this.genreName = form.value.genre)
  }
}
