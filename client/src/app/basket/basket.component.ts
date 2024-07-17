import {Component, Input, OnInit} from '@angular/core';
import {BasketService} from "./basket.service";
import {HttpClient} from "@angular/common/http";
import {CartItem} from "../shared/models/cartitem";
import {ITrack} from "../shared/models/track";
import {MatDialog} from "@angular/material/dialog";
import {CheckoutDialogComponent} from "./checkout-dialog/checkout-dialog.component";
import {Form, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  totalPrice !:number;
  public tracks : any []
  @Input() form : FormGroup;
  constructor(private cartService: BasketService, private httpClient:HttpClient, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.cartService.getTracksCart().subscribe(response => {
      this.totalPrice = this.cartService.getTotalPrice()
      this.tracks = response
    })
  }

  removeItem(track: any){
    this.cartService.removeCartITem(track);
  }

  addCartItem() {
    for(let track of this.tracks){
      this.cartService.addCartItem(track)
    }

  }

  openDialog() {
    this.matDialog.open(CheckoutDialogComponent)
  }

  submitForm(submitForm: FormGroup) {
    this.form = submitForm;
    console.log(submitForm)
  }
}
