import {CartItem} from "./cartitem";
import {MatTableDataSource} from "@angular/material/table";

export class Cart{
  id: number
  orderDate = new Date();
  subtotal: number;
  comment: string;
  // firstName: string;
  // lastName: string
  userId: number
  city: string;
  address: string;
  paymentMethod: string;
  payment: boolean;
  cartItems? : CartItem[] | MatTableDataSource<CartItem>;
}


