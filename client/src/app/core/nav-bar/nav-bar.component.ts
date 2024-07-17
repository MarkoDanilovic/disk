import {Component, Input, OnInit} from '@angular/core';
import {BasketService} from "../../basket/basket.service";
import {CheckoutDialogComponent} from "../../basket/checkout-dialog/checkout-dialog.component";
import {LoginDialogComponent} from "../login-dialog/login-dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {LoggingService} from "../logging.service";
import {RegisterDialogComponent} from "../register-dialog/register-dialog.component";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {


  totalItem = 0;

  logRole = localStorage.getItem('role')
  constructor(private cartService: BasketService, private matDialog:MatDialog, private logService: LoggingService) {



  }

  ngOnInit(): void {
    this.cartService.getTracksCart().subscribe(response => {
      this.totalItem = response.length;
    })
    console.log(localStorage.getItem('role'))
    console.log(localStorage.getItem('jwt'))
    //console.log(this.logRole)
    //localStorage.setItem("role", '')
  }

  openLoginDialog() {
    this.matDialog.closeAll()
    this.matDialog.open(LoginDialogComponent)
    this.logRole = localStorage.getItem('role')
  }

  openRegisterDialog() {
    this.matDialog.closeAll()
    let id =this.matDialog.open(RegisterDialogComponent).id

  }

  logout() {
    this.logService.logout();
    this.logRole = ''
    //location.reload()
  }
}
