export class TaxItem  {
    TaxCode: string = '';
    TaxBase: number = 0; 
    TaxAmount: number = 0;

    S4CalcAmount: number = 0; 
    Adjustments: number = 0; 
    TaxToPay: number = 0; 
    TaxAmtCalculated: number= 0;
    Note: string = ''; 
    IsOdd: boolean = false;
}