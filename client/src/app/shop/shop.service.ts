import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {IPagination} from "../shared/models/pagination";
import {IGenre} from "../shared/models/genre";
import {IMedium} from "../shared/models/medium";
import {map} from "rxjs";
import {ShopParams} from "../shared/models/shopParams";
import {ITrack} from "../shared/models/track";
import {BasketService} from "../basket/basket.service";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'http://localhost:1296/api/'

  constructor(private http: HttpClient, private cartService: BasketService) { }

  getProducts(shopParams: ShopParams){
    let params = new HttpParams();

    if(shopParams.genreId !== 0){
      params = params.append('genreId', shopParams.genreId.toString())
    }

    if(shopParams.mediumId !== 0){
      params = params.append('mediumId', shopParams.mediumId.toString())
    }

    if(shopParams.search){
      params = params.append('search', shopParams.search.toString())
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString())
    params = params.append('pageSize', shopParams.pageSize.toString())

    return this.http.get<IPagination>(this.baseUrl + 'track', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body
        })
      )
  }

  getTrack(id:number){
    return this.http.get<ITrack>(this.baseUrl + 'track/' + id)
  }


  getGenres(){
    return this.http.get<IGenre[]>(this.baseUrl+'track/genre')
  }

  getMediums(){
    return this.http.get<IMedium[]>(this.baseUrl+'track/medium')
  }

  addToCart(track: any){
    this.cartService.addToCart(track);

  }
}
