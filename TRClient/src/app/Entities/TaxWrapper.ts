import {TaxRemCAItem} from './TaxRemCAItem';
import {TaxItem}      from './TaxItem';
import {Awrapper}     from './Awrapper';

export class TaxWrapper extends Awrapper  {
 
    PeriodId: number = -1;
    Company: string = ''; 
    Vendor: string = '';

    PaymentMethod: string = ''; 
    DueDate: Date = new Date(1900,1,1); 
    JurisdictionCode: string = ''; 
    TaxId: string = ''; 
    DataEntryComplete: boolean = false; 
    PrevMthJourDiff: number = 0;
    DiffVsLastMthPaymnt: number = 0;
    ValidationComplete: number = 0;
    JournalDifference: number = 0;
    CalcVendorCommission: number = 0;
    CommissionNote: string = '';
    AvailTaxItems: TaxItem[] = [];
    AvailTaxRemCA: TaxRemCAItem[] = [];
 

    
 }