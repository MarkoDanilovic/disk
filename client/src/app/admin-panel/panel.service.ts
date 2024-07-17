import { Injectable } from '@angular/core';
import {IGenre} from "../shared/models/genre";
import {IMedium} from "../shared/models/medium";
import {Cart} from "../shared/models/cart";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {ITrack} from "../shared/models/track";
import {ILabel} from "../shared/models/label";
import {RegisterUser} from "../shared/models/registerUser";
import {IProducer} from "../shared/models/producer";
import {IUser} from "../shared/models/user";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PanelService {

  token = localStorage.getItem("jwt")



  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      Authorization: `Bearer ${this.token}`
    })
  };

  constructor(private httpClient: HttpClient) {

  }

  getGenres() {
    return this.httpClient.get<IGenre[]>('http://localhost:1296/api/track/genre')
  }
  getMediums() {
    return this.httpClient.get<IMedium[]>('http://localhost:1296/api/track/medium')
  }

  getCarts() : Observable<Cart[]>{
    return this.httpClient.get<Cart[]>('http://localhost:1296/api/cart')
  }
  getLabels() {
    return this.httpClient.get<ILabel[]>('http://localhost:1296/api/track/label')
  }

  getProducers() {
    return this.httpClient.get<IProducer[]>('http://localhost:1296/api/track/producer')
  }

  getTracks() {
    return this.httpClient.get<ITrack[]>('http://localhost:1296/api/track/trackall')
  }

  getUsers() {
    return this.httpClient.get<IUser[]>('http://localhost:1296/api/user/user')
  }

  insertGenre(genreName: string){
    console.log(genreName)
    this.httpClient.post('http://localhost:1296/api/track/genre', {'genreName' : genreName}, this.httpOptions ).subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  insertMedium(mediumName: string){
    console.log(mediumName)
    this.httpClient.post('http://localhost:1296/api/track/medium', {'mediumName' : mediumName}, this.httpOptions ).subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  insertTrack(trackName: string, price: number, duration: number, genre: string, producer: number, label: number, medium: number, publishDate: string, quantity: number){

    this.httpClient.post('http://localhost:1296/api/track', { 'trackName': trackName, 'price':price, 'duration':duration, 'publishDate': publishDate, 'pictureUrl': 'picture', 'quantity': quantity, 'labelId': label, 'mediumId':medium, 'producerId':producer, 'genreId' : genre}, this.httpOptions ).subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  insertLabel(name: string, country: string, email: string){
    console.log(name)
    this.httpClient.post('http://localhost:1296/api/track/label', {'name' : name,'email':email, 'country':country}, this.httpOptions ).subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  insertProducer(name: string, surname: string, email: string, artistName: string, birthday: string, country: string){
    //console.log(mediumName)
    this.httpClient.post('http://localhost:1296/api/track/producer', {'name' : name, 'surname':surname, 'email':email, 'artistName': artistName, 'birthday':birthday, 'country':country}, this.httpOptions ).subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  insertUser(name: string,lastname: string,email: string,password: string,address: string,country: string,city: string,telephone: string){
    console.log(name,lastname,email,password,address,country,city,telephone)
    this.httpClient.post('http://localhost:1296/api/user/user', {'name' : name,'lastname' : lastname,'password' : password,'email' : email,'address' : address,'country' : country,'city' : city,'telephone' : telephone}, this.httpOptions ).subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    })
    location.reload()
  }


  deleteGenre(id) {
    this.httpClient.delete('http://localhost:1296/api/track/genre/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  deleteMedium(id) {
    this.httpClient.delete('http://localhost:1296/api/track/medium/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  deleteTrack(id) {
    this.httpClient.delete('http://localhost:1296/api/track/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  deleteLabel(id) {
    this.httpClient.delete('http://localhost:1296/api/track/label/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  deleteProducer(id) {
    this.httpClient.delete('http://localhost:1296/api/track/producer/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  deleteUser(id) {
    this.httpClient.delete('http://localhost:1296/api/user/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    location.reload()
  }

  deleteCart(id) {
    this.httpClient.delete('http://localhost:1296/api/cart/'+id,this.httpOptions).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error)
    })
    //location.reload()
  }

}
