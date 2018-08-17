import { Component, OnInit,Input, Output, OnDestroy,EventEmitter,SimpleChanges, ViewEncapsulation }  from '@angular/core';
import { trigger, style, animate, transition }   from '@angular/animations';

import { GlobalCacheServices}                    from '../Services/GlobalCacheServices';
import { TaxRemittanceCAServices}                from '../Services/TaxRemittanceCAServices';
import { TaxItem}                                from '../Entities/TaxItem';
import { TaxWrapper}                             from '../Entities/TaxWrapper';

@Component({
    selector: 'glDtl-502563-dialog',
    templateUrl: './TaxDtl502563.dialog.html',
    styleUrls: ['./TaxDtl502563.dialog.css'],
    animations: [
        trigger('dialog', [
            transition('void => *', [
                style({ transform: 'scale3d(.3, .3, .3)' }),
                animate(100)
            ]),
            transition('* => void', [
                animate(100, style({ transform: 'scale3d(.0, .0, .0)' }))
            ])
        ])
    ]
})

export class TaxDtl502563dialog implements OnInit, OnDestroy {
   
     
    CurrPeriod: string;
    
    TotalTaxToPay: number;
    JobStatus: string = '';
    StatusClass: string = 'statusOK';
    // Fields from DB
    TaxWrapperFrmDB: TaxWrapper;
    VendorCommission: number = 0;
    AdjustmentTotal: number = 0;
    AdjustmentGross: number = 0;
    GrandTotal: number = 0;
    @Input() selected: string;
    @Input() visible: boolean = false;
    @Output() newReport: EventEmitter<boolean> = new EventEmitter<boolean>();

    constructor(
        private taxRemittanceCAServices : TaxRemittanceCAServices,
        private globalCacheServices: GlobalCacheServices )
    {      
         this.CurrPeriod = globalCacheServices.getCurrentPeriod.TextDesc;
    }
    ngOnInit() {
        this.TotalTaxToPay = 0;
        this.StatusClass = 'statusOK';
        this.TaxWrapperFrmDB = new TaxWrapper();
        this.TaxWrapperFrmDB.AvailTaxItems = [];
    }
    ngOnDestroy() {
       
    }
    ngOnChanges(changes: SimpleChanges) {
        if (changes.selected != null ) {
            if (changes.selected.currentValue != '') {
                let vm = this;
                
                this.CurrPeriod = this.globalCacheServices.getCurrentPeriod.TextDesc;
                this.taxRemittanceCAServices.GetTaxDetails(this.globalCacheServices.getCurrentPeriod.ValueId, '502563')
                    .subscribe(function (response: TaxWrapper) {
                    vm.TaxWrapperFrmDB = response;
                    let isodd: boolean = false;
                    if (response.hasAnError)
                    {                                                          
                        vm.StatusClass = "statusErr";
                        vm.JobStatus = response.errMessage;
                    } else {
                        vm.TaxWrapperFrmDB.AvailTaxItems.forEach(function (item: TaxItem){
                            item.IsOdd = isodd;
                            isodd =!isodd;
                            vm.TotalTaxToPay += item.TaxAmtCalculated;
                            vm.AdjustmentTotal += item.Adjustments;
                            
                        });
                        vm.AdjustmentGross = vm.TaxWrapperFrmDB.CalcVendorCommission + vm.AdjustmentTotal;
                        vm.GrandTotal = vm.AdjustmentGross + vm.TotalTaxToPay;
                    };                     
                });
            }
        }
    }
    close()
    {
        this.visible = false;
       
        this.newReport.emit(true);
    }
}