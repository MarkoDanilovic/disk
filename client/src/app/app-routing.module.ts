import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {ShopComponent} from "./shop/shop.component";
import {TrackDetailsComponent} from "./shop/track-details/track-details.component";
import {AuthService} from "./shared/auth.service";
import {GuardGuard} from "./shared/guard.guard";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule) },
  {path: 'admin', loadChildren: () => import('./admin-panel/admin-panel.module').then(mod => mod.AdminPanelModule), canLoad:[GuardGuard]},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  {path: '**', redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
