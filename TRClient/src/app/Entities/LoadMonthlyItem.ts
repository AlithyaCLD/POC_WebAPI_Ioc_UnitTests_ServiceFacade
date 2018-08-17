export class LoadMonthlyItem  {
    ImportType: string
    ImportDate: Date;  
    FileName: string;
    IsOdd: boolean;
    constructor() { 
        this.ImportType = '';
        this.FileName = '';
        this.ImportDate = new Date();
        this.IsOdd = false;
     }
 }