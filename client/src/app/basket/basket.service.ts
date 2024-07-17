import {Injectable, Output} from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {CartItem} from "../shared/models/cartitem";
import {HttpClient} from "@angular/common/http";
import {FormGroup} from "@angular/forms";
import {Cart} from "../shared/models/cart";
import {MatDialog} from "@angular/material/dialog";
import {ISession} from "../shared/models/session";

declare const Stripe;


@Injectable({
  providedIn: 'root'
})
export class BasketService {

  public cartItemList : any = []

  public cart : Cart = new Cart()
  cartItems = [] as CartItem[]

  baseUrl = 'http://localhost:1296/api/'
  public trackList = new BehaviorSubject<any>([]);

  loggedIn = localStorage.getItem('role');

  constructor(private httpClient: HttpClient, private mat: MatDialog) { }

  getTracksCart(){
    return this.trackList.asObservable();
  }

  setTrackCart(track: any){
    this.cartItemList.push(...track);
    this.trackList.next(track);
  }

  addToCart(track: any){
    this.cartItemList.push(track)
    this.trackList.next(this.cartItemList)
    this.getTotalPrice();
    console.log(this.cartItemList)
  }

  getTotalPrice(): number{
    let grandTotal = 0;
    this.cartItemList.map((a:any) => {
      grandTotal += a.price;
    })
    return grandTotal;
  }

  removeCartITem(track : any){
    this.cartItemList.map((a:any, index:any) => {
      if(track.id === a.id){
        this.cartItemList.splice(index,1)
      }
    })
    //console.log(this.cartItemList)
    this.trackList.next(this.cartItemList)
  }

  removeAllCart(){
    this.cartItemList = []
    this.cartItems = []
    this.trackList.next(this.cartItemList)
  }


  addCartItem(track: any) {
    let cartItem = new CartItem();
    cartItem.trackId = track.id;
    cartItem.quantity = 1
    //this.cart.cartItems.push(cartItem);

    /*
    this.httpClient.post<CartItem>('https://localhost:1296/api/cartitem', cartItem).subscribe(data => {
      console.log(data)
    });
    */
    this.cartItems.push(cartItem)
    console.log(this.cartItems)
  }

  addCart(form: FormGroup){


    // this.cart.firstName = form.get('firstName').value;
    // this.cart.lastName = form.get('lastName').value;
    this.cart.address = form.get('address').value;
    this.cart.city = form.get('city').value;
    this.cart.payment = false
    this.cart.paymentMethod = form.get('paymentMethod').value
    this.cart.cartItems = this.cartItems
    this.cart.comment = form.get('comment').value
    this.cart.subtotal = this.getTotalPrice()
    this.cart.userId = +localStorage.getItem('currentUserId')
    console.log(this.cart)

    this.httpClient.post<Cart>('http://localhost:1296/api/cart', this.cart).subscribe(data => {
      console.log(data.id)
      this.requestMemberSession(data.id)
    });
    this.removeAllCart()
    this.mat.closeAll()



  }

  // requestMemberSession(priceId: string){
  //   this.httpClient.post<ISession>('http://localhost:1296/api/payment/create-checkout-session',{
  //     priceId: priceId,
  //   }).subscribe((session) => {
  //     this.redirectToCheckout(session);
  //   });
  // }

  requestMemberSession(cartId: number){
    console.log(cartId)
    this.httpClient.post<ISession>('http://localhost:1296/api/payment/checkout/'+cartId,{}).subscribe((response) => {
      //console.log(session)

      this.toCheckout(response.publicKey, response.sessionId);
    });
  }

  // toCheckout(session: ISession){
  //   console.log(session)
  //   console.log("toCheckout metoda")
  //   const stripe = Stripe(session.publicKey)
  //   console.log(stripe)
  //   stripe.redirectToCheckout(session.sessionId)
  // }

  toCheckout(publicKey: String, sessionId :String){
    console.log(sessionId)
    console.log(publicKey)
    const stripe = Stripe(publicKey)
    stripe.redirectToCheckout({
      sessionId: sessionId,
    })
  }
}
