import { Component, OnInit, OnDestroy, ViewEncapsulation }  from '@angular/core';

import { TaxRemittanceCAServices}         from '../Services/TaxRemittanceCAServices';
import { GlobalCacheServices}             from '../Services/GlobalCacheServices';
import { ChangeNotifyServices}            from '../Services/ChangeNotifyServices';
import { UiOverRideServices}              from '../Services/UiOverRideServices';
import { TaxRemCAItem}                    from '../Entities/TaxRemCAItem';
import { TaxWrapper}                      from '../Entities/TaxWrapper';
import { NotifyMsg }                      from '../Entities/NotifyMsg';
 
 
@Component({
    selector: 'processTax',
    templateUrl: './ProcessTaxCAD.html',
    encapsulation: ViewEncapsulation.None
})

export class ProcessTaxCADComponent implements OnInit, OnDestroy {
    PeriodEnd: string;
    StatusClass: string = 'statusOK';
    TaxRemCAItems: TaxRemCAItem[];
    JobStatus: string;
    showDialog502009: boolean;
    showDialog502010: boolean;
    showDialog502563: boolean;
    showDialog502103A: boolean;
    showDialog502103B: boolean;
   // visible: boolean;
    selected502563: string = '';
    selected502009: string = '';
    selected502010: string = '';
    selected502103A: string = '';
    selected502103B: string = '';
    constructor(
        private taxRemittanceCAServices: TaxRemittanceCAServices,
        private changeNotifyServices: ChangeNotifyServices,
        private globalCacheServices: GlobalCacheServices,
        private uiOverRideServices : UiOverRideServices )
    {
        let vm = this;
        this.taxRemittanceCAServices.setUrl = this.globalCacheServices.getUrl;
        this.changeNotifyServices.getPeriodChanged().subscribe((logged: NotifyMsg) => {
             vm.PeriodEnd = vm.globalCacheServices.getCurrentPeriod.TextDesc;            
        });            
            
    }
    ngOnInit() {
        this.ClearFlags()
        this.TaxRemCAItems = [];
        this.PeriodEnd = this.globalCacheServices.getCurrentPeriod.TextDesc;
        let vm = this;
        vm.StatusClass = '';
        this.taxRemittanceCAServices.getRemCAForPeriod(this.globalCacheServices.getCurrentPeriod.ValueId)
            .subscribe((taxRemittanceCAWrapper: TaxWrapper) => {
                if (!taxRemittanceCAWrapper.hasAnError) {
                    vm.TaxRemCAItems = taxRemittanceCAWrapper.AvailTaxRemCA;
                } else {
                    vm.TaxRemCAItems = [];
                }
                if (vm.TaxRemCAItems.length == 0) {
                    vm.JobStatus = "Found No Data";
                    vm.StatusClass = "statusErr";
                }
                console.log(taxRemittanceCAWrapper);
             });
    }
    ngOnDestroy() {
       
    }
    getDetails(glCode : string,typeTax: string) {
        this.ClearFlags();
        this.globalCacheServices.setGLCode = glCode;
        switch (glCode) {
            case '502009':
              this.showDialog502009 = true;
              this.selected502009 = '502009';
              break;
            case '502010':
              this.showDialog502010 = true;
              this.selected502010 = '502010';
              break;
            case '502563':
              this.showDialog502563 = true; 
              this.selected502563 = '502563';
              break;
            case '502103':             
                if (typeTax == 'Fuel Tax') {
                    this.showDialog502103A = true; 
                    this.selected502103A = '502103A';
                } else {
                    this.showDialog502103B = true;   
                    this.selected502103B = '502103B';                 
                }            
              break;
        }
        
    }
    getLegendColor(colorNo: number,textAlign: string)  {

      
        var styles = this.uiOverRideServices.getLegendColors(colorNo,textAlign);
        
        return styles;
    }
    closeRpt(event: any) {
        this.ClearFlags();
        
    }
    private ClearFlags() {
        this.showDialog502009 = false; 
        this.showDialog502010 = false; 
        this.showDialog502563 = false; 
        this.showDialog502103A = false; 
        this.showDialog502103B = false; 
        this.selected502563 = '';      
       
        this.selected502010 = '';
        this.selected502103A = '';
        this.selected502103B = '';
    }
}