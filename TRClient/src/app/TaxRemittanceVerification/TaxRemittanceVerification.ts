import { Component, OnInit, OnDestroy, ViewEncapsulation }  from '@angular/core';

import { GlobalCacheServices}                    from '../Services/GlobalCacheServices';
import { ChangeNotifyServices}                   from '../Services/ChangeNotifyServices';
import { NotifyMsg }                             from '../Entities/NotifyMsg';
@Component({
    selector: 'taxRemVercif',
    templateUrl: './TaxRemittanceVerification.html',
    encapsulation: ViewEncapsulation.None
})

export class TaxRemVerificationComponent implements OnInit, OnDestroy {
    CurrPeriod: string;
    showDialog: boolean = false;
    selectedRptNo: number;
    rptNo1 = "Display Account Balance";
    rptNo2 = "US Tax Juris. not included in current Tax remittance";
    rptNo3 = "Display current Period's Selected Line item";
    rptNo4 = "Display All Selected Line items";
    rptNo5 = "Display All Line items for All Periods";
    rptNo6 = "Display All Line Items filtered by:";
    rptNo7 = "Display Tax process table";
    rptNo8 = "Display Fuel table";
    rptNo9 = "Display 1210 Verification Items";
    constructor(
         
        private globalCacheServices: GlobalCacheServices,
        private changeNotifyServices: ChangeNotifyServices, )
    {
        let vm = this;
        
        this.changeNotifyServices.getPeriodChanged().subscribe((logged: NotifyMsg) => {
             vm.CurrPeriod = vm.globalCacheServices.getCurrentPeriod.TextDesc;            
        });          
        //    this.loadMonthlyServices.setUrl = this.globalCacheServices.getUrl;
        if (globalCacheServices.getCurrentPeriod !== null) {
            this.CurrPeriod = globalCacheServices.getCurrentPeriod.TextDesc;
        }
            
    }

    ngOnInit() {
    
       this.showDialog = false;
    }
    ngOnDestroy() {
       
    }
    displayRpt(rptNo: number) {
        this.globalCacheServices.setCurrRptNo = rptNo;
        switch (rptNo)
        {
            case 1:
                this.globalCacheServices.setCurrRptDesc = this.rptNo1;
                break;
            case 2:
                this.globalCacheServices.setCurrRptDesc = this.rptNo2;
                break;
            case 3:
                this.globalCacheServices.setCurrRptDesc = this.rptNo3;
                break;
            case 4:
                this.globalCacheServices.setCurrRptDesc = this.rptNo4;
                break;
            case 5:
                this.globalCacheServices.setCurrRptDesc = this.rptNo5;
                break;
            case 6:
                this.globalCacheServices.setCurrRptDesc = this.rptNo6;
                break;
            case 7:
                this.globalCacheServices.setCurrRptDesc = this.rptNo7;
                break;
            case 8:
                this.globalCacheServices.setCurrRptDesc = this.rptNo8;
                break;
            case 9:
                this.globalCacheServices.setCurrRptDesc = this.rptNo9;
                break;
        }
        this.showDialog = true; 
        // selectedRptNo
       
    }
    closeRpt(event: any) {
        this.showDialog = false; 
    }

}