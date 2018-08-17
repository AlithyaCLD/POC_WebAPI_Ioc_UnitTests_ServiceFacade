import { Component, OnInit,Input, Output, OnDestroy,EventEmitter,SimpleChanges }  from '@angular/core';
import { trigger, style, animate, transition }   from '@angular/animations';

import { GlobalCacheServices}                    from '../Services/GlobalCacheServices';
import { TaxRemittanceCAServices}                from '../Services/TaxRemittanceCAServices';
import { CarbonFuelTax}                          from '../Entities/CarbonFuelTax';
import { CarbonFuelTaxWrapper}                   from '../Entities/CarbonFuelTaxWrapper';

@Component({
    selector: 'glDtl-502103A-dialog',
    templateUrl: './TaxDtl502103A.dialog.html',
    styleUrls: ['./TaxDtl502103A.dialog.css'],
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

export class TaxDtl502103Adialog implements OnInit, OnDestroy {
   
     
    CurrPeriod: string; 
    JobStatus: string = '';
    StatusClass: string = 'statusOK';
    // Fields from DB
    carbonFuelTaxWrapperFrmDB: CarbonFuelTaxWrapper;
   
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
        
        this.StatusClass = 'statusOK';
        this.carbonFuelTaxWrapperFrmDB = new CarbonFuelTaxWrapper();
        this.carbonFuelTaxWrapperFrmDB.AvailFuelTax = [];
    }
    ngOnDestroy() {
       
    }
    ngOnChanges(changes: SimpleChanges) {
        if (changes.selected != null ) {
            if (changes.selected.currentValue != '') {
                let vm = this;                
                this.CurrPeriod = this.globalCacheServices.getCurrentPeriod.TextDesc;
                this.taxRemittanceCAServices.getTax502103(this.globalCacheServices.getCurrentPeriod.ValueId, '502103A')
                    .subscribe(function (response: CarbonFuelTaxWrapper) {
                    vm.carbonFuelTaxWrapperFrmDB = response;
                    let isodd: boolean = false;
                    if (response.hasAnError)
                    {                                                          
                        vm.StatusClass = "statusErr";
                        vm.JobStatus = response.errMessage;
                    } else {
                        vm.carbonFuelTaxWrapperFrmDB.AvailFuelTax.forEach(function (item: CarbonFuelTax){
                            item.IsOdd = isodd;
                            isodd =!isodd;                           
                        });
                    };  
                    console.log(vm.carbonFuelTaxWrapperFrmDB) ;
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