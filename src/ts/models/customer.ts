import {Item} from "./item"

export class Customer {
  id: string = "";
  name: string = "";
  companyName: string = "";
  email: string = "";
  contactNo: number = 0;
  address: string = "";
  userId: string = "";
  createdAt: Date = new Date();
  updatedAt:Date = new Date();
  sortNo: number = 1;
  Items:Item[]|null = [];
 }