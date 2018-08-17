import { Component, OnInit, OnDestroy, ViewEncapsulation }  from '@angular/core';

import { TaxRemittanceCAServices}         from '../Services/TaxRemittanceCAServices';
import { GlobalCacheServices}             from '../Services/GlobalCacheServices';
import { ChangeNotifyServices}            from '../Services/ChangeNotifyServices';
import { TaxRemCAItem}                    from '../Entities/TaxRemCAItem';
import { TaxWrapper}                      from '../Entities/TaxWrapper';
import { NotifyMsg }                      from '../Entities/NotifyMsg';

@Component({
    selector: 'ExportTemplates',
    templateUrl: './ExportTemplates.html',
    encapsulation: ViewEncapsulation.None
})

export class ExportTemplatesComponent implements OnInit, OnDestroy {
    PeriodEnd: string;
    StatusClass: string = 'statusOK';
    TaxRemCAItems: TaxRemCAItem[];
    JobStatus: string;
    showDialog502009: boolean;
    showDialog502563: boolean;
   // visible: boolean;
    selected502563: string = '';
    selected502009: string = '';
    constructor(
        private taxRemittanceCAServices: TaxRemittanceCAServices,
        private changeNotifyServices: ChangeNotifyServices,
        private globalCacheServices: GlobalCacheServices )
    {
        let vm = this;
        this.taxRemittanceCAServices.setUrl = this.globalCacheServices.getUrl;
        this.changeNotifyServices.getPeriodChanged().subscribe((logged: NotifyMsg) => {
             vm.PeriodEnd = vm.globalCacheServices.getCurrentPeriod.TextDesc;            
        });            
            
    }
    ngOnInit() {
        
        this.showDialog502009 = false;
        this.showDialog502563 = false;
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
    getDetails(glCode : string) {
        
        this.globalCacheServices.setGLCode = glCode;
        switch (glCode) {
            case '502009':
            console.log(' ' +glCode);
              this.showDialog502009 = true;
              this.selected502009 = '502009';
              this.selected502563 = ''
              break;
            case '502563':
              this.showDialog502563 = true;
              this.selected502009 = '';
              this.selected502563 = '502563';
              break;
        }
        
    }
    closeRpt(event: any) {
        
        this.showDialog502009 = false; 
        this.showDialog502563 = false; 
    }
}