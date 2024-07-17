import { Component, OnInit } from '@angular/core';
import {ITrack} from "../../shared/models/track";
import {ShopService} from "../shop.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-track-details',
  templateUrl: './track-details.component.html',
  styleUrls: ['./track-details.component.scss']
})
export class TrackDetailsComponent implements OnInit {

  track:ITrack

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadTrack()
  }


  loadTrack(){
    this.shopService.getTrack(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(track => {
      this.track = track
    }, error => {
      console.log(error)
    })
  }

  addToCart(track: ITrack) {
    this.shopService.addToCart(track);
  }
}
