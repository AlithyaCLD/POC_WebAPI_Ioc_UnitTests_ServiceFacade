import { Component,OnInit, OnDestroy,ViewEncapsulation } from '@angular/core';
import { HttpClient }                                    from '@angular/common/http';

import { TaxReportServices}         from '../Services/TaxReportServices';
import { GlobalCacheServices}       from '../Services/GlobalCacheServices';
import { DropDownsWrapper }         from '../Entities/DropDownsWrapper';
import { DropDownItem }             from '../Entities/dropDownItem';
import { NotifyMsg }                from '../Entities/NotifyMsg';

import { ConstantsServices }        from '../Services/ConstantsServices';
import { ChangeNotifyServices}      from '../Services/ChangeNotifyServices';

import { environment } from '../../environments/environment';
import { TaxReportWrapper } from '../Entities/TaxReportWrapper';

@Component({
    selector: 'generateTaxAmtRpt',
    templateUrl: './generateTaxAmtRpt.html',
    encapsulation: ViewEncapsulation.None
})

export class GenerateTaxAmtRptComponent implements OnInit, OnDestroy {
    //title = 'app';
    selectedStartPeriodId: number = 0;
    selectedEndPeriodId: number = 0;
    selectedTaxTypeId: number = 0;
    selectedVaucherId: number = 0;
    
    // selectedTaxType
    
    availStartPeriods : DropDownItem[];
    availEndPeriods : DropDownItem[];
    availTaxTypes : DropDownItem[];
    availVauchers : DropDownItem[];

    constructor(private http: HttpClient,
                private taxReportServices: TaxReportServices,
                private changeNotifyServices: ChangeNotifyServices,
                private constantsServices: ConstantsServices,
                private globalCacheServices: GlobalCacheServices )
    {
         
      this.taxReportServices.setHttp = http;
      this.taxReportServices.setUrl = constantsServices.getCORSUrl;  
          
    }

    ngOnInit() { 
    
        var vm = this; 
        var dt = new Date(2018,8,13);
        this.taxReportServices.getDropDownFrmDbC(dt)
            .subscribe(function (response: TaxReportWrapper) {
                vm.availEndPeriods = response.AvailEndPeriod;
                vm.availStartPeriods = response.AvailStartPeriod;
                vm.availTaxTypes = response.AvailTaxTypes;
                vm.availVauchers = response.AvailVoucherId;
        });
    }
    ngOnDestroy() {
       
    }
    onChangeChanged(newValue : number, dropDownType : number)
    {
        var vm = this;
        switch(dropDownType) {
            case 2: {
                this.selectedStartPeriodId = newValue;
                var newStartPeriod = this.availStartPeriods.find(function (item: DropDownItem) {
                    return (item.ValueId == vm.selectedStartPeriodId );
                });
                break;
            }
            case 3: {
                this.selectedStartPeriodId = newValue;
                var newEndPeriod = this.availEndPeriods.find(function (item: DropDownItem) {
                    return (item.ValueId == vm.selectedEndPeriodId );
                });
                break;
            }
            case 4: {
                this.selectedStartPeriodId = newValue;
                var newTaxType = this.availTaxTypes.find(function (item: DropDownItem) {
                    return (item.ValueId == vm.selectedTaxTypeId );
                });
                break;
            }
            case 5: {
                this.selectedStartPeriodId = newValue;
                var newVaucher = this.availVauchers.find(function (item: DropDownItem) {
                    return (item.ValueId == vm.selectedVaucherId );
                });
                break;
            }

        }

        if (newStartPeriod != null) {
           
            let notifyMsg = new NotifyMsg();
            notifyMsg.Period = newStartPeriod.TextDesc;
            notifyMsg.Reload = true;
            this.changeNotifyServices.setPeriodChanged(notifyMsg);
            // changeNotifyServices
        }
        if (newEndPeriod != null) {
            
            let notifyMsg = new NotifyMsg();
            notifyMsg.Period = newEndPeriod.TextDesc;
            notifyMsg.Reload = true;
            this.changeNotifyServices.setPeriodChanged(notifyMsg);
            // changeNotifyServices
        }
        if (newTaxType != null) {
           
            let notifyMsg = new NotifyMsg();
            notifyMsg.Period = newTaxType.TextDesc;
            notifyMsg.Reload = true;
            this.changeNotifyServices.setPeriodChanged(notifyMsg);
            // changeNotifyServices
        }
        if (newVaucher != null) {
            
            let notifyMsg = new NotifyMsg();
            notifyMsg.Period = newVaucher.TextDesc;
            notifyMsg.Reload = true;
            this.changeNotifyServices.setPeriodChanged(notifyMsg);
            // changeNotifyServices
        }
    }
}