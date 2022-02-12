import {Item} from "./item"
export class Disposition {
  id: number = 0;
  dispositionNo: number = 0;
  shippedAt: string|null = null;
  shippedFrom: string = "";
  note: string = "";
  createdAt: string|null = null;
  updatedAt:string|null = null;
  item:Item | null = null;
  // status: string = "";
 }