import {CarbonFuelTax} from './CarbonFuelTax';
import {FuelTaxDtl}    from './FuelTaxDtl';
import {Awrapper}      from './Awrapper';

export class CarbonFuelTaxWrapper  extends Awrapper {
  
    AvailFuelTax: CarbonFuelTax[];
    AvailFuelTaxDtl: FuelTaxDtl[];
    VendorNo: string;
    TaxId: string;
    PaymentMethod: string;
    DueDate: Date;
    TotalLitresToPay: number;
    TotalToPay: number;
   
 }