import { Component, OnInit,Input, Output, OnDestroy,EventEmitter,SimpleChanges, ViewEncapsulation }  from '@angular/core';
import { trigger, style, animate, transition } from '@angular/animations';

import { GlobalCacheServices}                    from '../Services/GlobalCacheServices';
import { DropDownItem}                           from '../Entities/dropDownItem';
import { LoadMonthlyWrapper}                     from '../Entities/LoadMonthlyWrapper';

@Component({
    selector: 'glDtl-dialog',
    templateUrl: './GlDetails.dialog.html',
    styleUrls: ['./GlDetails.dialog.css'],
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

export class GlDetailsComponent implements OnInit, OnDestroy {
    CurrPeriod: string;
    CurrRptDesc: string;
    CurrRptNo: number;
    @Input() visible: boolean = false;
    @Input() RptNo: any;
    @Output() newReport: EventEmitter<boolean> = new EventEmitter<boolean>();

    showDialog502009: boolean;

    constructor(
         
        private globalCacheServices: GlobalCacheServices )
    {
            this.RptNo = -1;
            this.CurrPeriod = globalCacheServices.getCurrentPeriod.TextDesc;
    }

    ngOnInit() {
         console.log('Inside*************');
     
         this.CurrPeriod = this.globalCacheServices.getCurrentPeriod.TextDesc;
         this.CurrRptDesc = this.globalCacheServices.getCurrRptDesc;
         this.CurrRptNo = this.globalCacheServices.getCurrRptNo;
    }
    ngOnDestroy() {
       
    }
    ngOnChanges(changes: SimpleChanges) {
        this.CurrPeriod = this.globalCacheServices.getCurrentPeriod.TextDesc;
        this.CurrRptDesc = this.globalCacheServices.getCurrRptDesc;
        this.CurrRptNo = this.globalCacheServices.getCurrRptNo;
    }
    close()
    {
        this.visible = false;
       
        this.newReport.emit(true);
    }
}