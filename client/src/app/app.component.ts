import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IPagination} from "./shared/models/pagination";
import {ITrack} from "./shared/models/track";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Disk';


  constructor() {
  }

  ngOnInit(): void {

  }
}
