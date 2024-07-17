import {ChangeDetectorRef, Component, OnInit, QueryList, ViewChildren} from '@angular/core';
import {GenreDialogComponent} from "../genre-dialog/genre-dialog.component";
import {IGenre} from "../../shared/models/genre";
import {IMedium} from "../../shared/models/medium";
import {CartItem} from "../../shared/models/cartitem";
import {Cart} from "../../shared/models/cart";
import {PanelService} from "../panel.service";
import {MatDialog} from "@angular/material/dialog";
import {MatTable, MatTableDataSource} from "@angular/material/table";
import {ITrack} from "../../shared/models/track";
import {ILabel} from "../../shared/models/label";
import {IProducer} from "../../shared/models/producer";
import {RegisterUser} from "../../shared/models/registerUser";
import {IUser} from "../../shared/models/user";
import {MediumDialogComponent} from "../medium-dialog/medium-dialog.component";
import {TrackDialogComponent} from "../track-dialog/track-dialog.component";
import {LabelDialogComponent} from "../label-dialog/label-dialog.component";
import {ProducerDialogComponent} from "../producer-dialog/producer-dialog.component";
import {UserDialogComponent} from "../user-dialog/user-dialog.component";
import {animate, state, style, transition, trigger} from "@angular/animations";
import {CartDataSource} from "../../shared/models/cartDataSource";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class AdminComponent implements OnInit {

  genres: IGenre[]
  genreDataSource: MatTableDataSource<IGenre>
  displayedColumnsGenre = ['id', 'genreName', 'actions']

  mediums: IMedium[]
  mediumDataSource: MatTableDataSource<IMedium>
  displayedColumnsMedium = ['id', 'mediumName', 'actions']

  cartData: Cart[] = [];
  cartDataSource: MatTableDataSource<Cart>
  displayedColumnsCart = ['id', 'orderDate', 'subtotal', 'comment', 'address', 'paymentMethod', 'payment', 'city', 'firstName', 'lastName', 'actions']
  displayedColumnsCartInner = ['cartId', 'trackId', 'quantity']
  expandedElement: Cart | null;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<CartItem>>;
  //cartItems: CartItem[]

  track: ITrack[]
  trackDataSource: MatTableDataSource<ITrack>
  displayedColumnsTrack = ['id', 'trackName', 'genre', 'label', 'medium', 'producer', 'duration', 'price', 'quantity', 'publishDate', 'actions']


  labels: ILabel[]
  labelDataSource: MatTableDataSource<ILabel>
  displayedColumnsLabel = ['id', 'name', 'country', 'email', 'actions']

  producers: IProducer[]
  producerDataSource: MatTableDataSource<IProducer>
  displayedColumnsProducer = ['id', 'name', 'surname', 'email', 'artistName', 'birthday', 'country', 'actions']

  users: IUser[]
  userDataSource: MatTableDataSource<IUser>
  displayedColumnsUser = ['id', 'name', 'lastname', 'email', 'password', 'city', 'address', 'country', 'role', 'telephone', 'actions']


  constructor(private panelService: PanelService, private matDialog: MatDialog, private cd: ChangeDetectorRef) {
  }

  ngOnInit(): void {
    this.getGenres()
    this.getMediums()
    this.getCart()
    this.getTrack()
    this.getLabel()
    this.getProducer()
    this.getUsers()
  }

  toggleRow(element: Cart) {
    element.cartItems && (element.cartItems as MatTableDataSource<CartItem>).data.length ? (this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.cd.detectChanges();

    //this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<CartItem>).sort = this.innerSort.toArray()[index]);
  }


  getGenres() {
    this.panelService.getGenres().subscribe(response => {
      this.genres = response
      this.genreDataSource = new MatTableDataSource<IGenre>(response);
      //console.log(this.genreDataSource)

    }, error => {
      console.log(error)
    })
  }


  getMediums() {
    this.panelService.getMediums().subscribe(response => {
      this.mediums = response
      this.mediumDataSource = new MatTableDataSource<IMedium>(response)
      //console.log(this.mediums)
    }, error => {
      console.log(error)
    })
  }

  getCart() {
    this.panelService.getCarts().subscribe(response => {
      //this.cart = response
      response.forEach(cart => {

        if (cart.cartItems && Array.isArray(cart.cartItems) && cart.cartItems.length) {
          this.cartData = [...this.cartData, {...cart, cartItems: new MatTableDataSource(cart.cartItems)}];
        } else {
          this.cartData = [...this.cartData, cart];
        }
      })
      console.log(this.cartData)
      this.cartDataSource = new MatTableDataSource<Cart>(this.cartData)

    }, error => {
      console.log(error)
    })
  }

  getTrack() {
    this.panelService.getTracks().subscribe(response => {
      this.track = response
      this.trackDataSource = new MatTableDataSource<ITrack>(response)
      //console.log(this.track)
    }, error => {
      console.log(error)
    })
  }

  getLabel() {
    this.panelService.getLabels().subscribe(response => {
      this.labels = response
      this.labelDataSource = new MatTableDataSource<ILabel>(response)
      //console.log(this.labelDataSource)
    }, error => {
      console.log(error)
    })
  }

  getProducer() {
    this.panelService.getProducers().subscribe(response => {
      this.producers = response
      this.producerDataSource = new MatTableDataSource<IProducer>(response)
      //console.log(this.producers)
    }, error => {
      console.log(error)
    })
  }

  getUsers() {
    this.panelService.getUsers().subscribe(response => {
      this.users = response
      this.userDataSource = new MatTableDataSource<IUser>(response)
      //console.log(this.users)
    }, error => {
      console.log(error)
    })
  }

  insertGenre() {
    this.matDialog.open(GenreDialogComponent)
  }

  insertMedium() {
    this.matDialog.open(MediumDialogComponent)
  }

  insertLabel() {
    this.matDialog.open(LabelDialogComponent)
  }

  insertProducer() {
    this.matDialog.open(ProducerDialogComponent)
  }

  insertUser() {
    this.matDialog.open(UserDialogComponent)
  }

  insertTrack() {
    this.matDialog.open(TrackDialogComponent, {
      data: {
        IProducer: this.producers,
        ILabel: this.labels,
        IMedium: this.mediums,
        IGenre: this.genres
      }
    })
  }

  deleteGenre(id: string) {
    this.panelService.deleteGenre(id)
  }

  deleteMedium(id: string) {
    this.panelService.deleteMedium(id)
  }

  deleteTrack(id: string) {
    this.panelService.deleteTrack(id)
  }

  deleteLabel(id: string) {
    this.panelService.deleteLabel(id)
  }

  deleteProducer(id: string) {
    this.panelService.deleteProducer(id)
  }

  deleteUser(id: string) {
    this.panelService.deleteUser(id)
  }

  deleteCart(id: string) {
     this.panelService.deleteCart(id)

  }
}

