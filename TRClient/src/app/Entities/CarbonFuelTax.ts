export class CarbonFuelTax  {
    Completed:boolean;
    Jurisdiction: string
    AmtFreightTrain: number;  
    AmtWorkTrain: number;  
    AmtYardSwitching: number;  
    AmtTotalLine: number;  
    Adjustment: number;  
    TotalLitresToPay: number;  
    RatePerLitre: number;  
    TotalToPay: number;  
    PercDiff: number;  
    TotalLitres: number;
    IsOdd: boolean;
    constructor() { 
        this.Completed = false;
        this.Jurisdiction = '';
        this.AmtFreightTrain = 0;
        this.AmtWorkTrain = 0;
        this.AmtYardSwitching = 0;
        this.AmtTotalLine = 0;
        this.Adjustment = 0;
        this.TotalLitresToPay = 0;
        this.RatePerLitre = 0;
        this.TotalToPay = 0;
        this.PercDiff = 0;
        this.TotalLitres = 0;
        this.IsOdd = false;
     }
 }