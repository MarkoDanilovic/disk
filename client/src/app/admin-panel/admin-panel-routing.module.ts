import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ShopComponent} from "../shop/shop.component";
import {AdminComponent} from "./admin/admin.component";

const routes: Routes = [

  {path: '', component:AdminComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPanelRoutingModule { }
