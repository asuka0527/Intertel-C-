import {Status} from "./status"
import {Disposition} from "./disposition"
export class Item {
 id: string = "";
 agentId: string|null = null;
 boxNo: string|null = null;
 userId: string|null = null;
 model: string|null = null;
 serialNo:string|null = null;
 macNo1:string|null = null;
 macNo2:string|null = null;
 note:string|null = null;
 quantity:number  = 0;
 purchasePrice:number  = 0;
 retailPrice:number  = 0;
 location:string|null = null;
 symptom:string|null = null;
 invoiceAt: string|null = null;
 soldAt: string|null = null;
 shippedAt: string|null = null;
 createdAt: string|null = null;
 updatedAt:string|null = null;
 status: Status | null = null;
 dispositions: Disposition[] | null = null;

}