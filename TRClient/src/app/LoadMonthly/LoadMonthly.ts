import { Component, OnInit, OnDestroy, ViewEncapsulation }  from '@angular/core';

import { GlobalCacheServices}            from '../Services/GlobalCacheServices';
import { LoadMonthlyServices}            from '../Services/LoadMonthlyServices';
import { ChangeNotifyServices}           from '../Services/ChangeNotifyServices';
import { LoadMonthlyItem}                from '../Entities/LoadMonthlyItem';
import { LoadMonthlyWrapper}             from '../Entities/LoadMonthlyWrapper';
import { NotifyMsg }                     from '../Entities/NotifyMsg';

@Component({
    selector: 'loadMthly',
    templateUrl: './LoadMonthly.html',
    encapsulation: ViewEncapsulation.None
})

export class LoadMonthlyComponent implements OnInit, OnDestroy {

    JobStatus: string = '';
    StatusClass: string = 'statusOK';
    // Field used display
    PeriodEnd: string;
    availLogEntries: LoadMonthlyItem[];
    chkBox1: boolean;
    chkBox2: boolean;
    chkBox3: boolean;
    chkBox4: boolean;
    chkBox5: boolean;
    // End of display fields 

    // Section to define Excel export

    constructor(
        private loadMonthlyServices: LoadMonthlyServices,
        private changeNotifyServices: ChangeNotifyServices,
        private globalCacheServices: GlobalCacheServices )
    {
            this.loadMonthlyServices.setUrl = this.globalCacheServices.getUrl;
            let vm = this;
                 
            this.changeNotifyServices.getPeriodChanged().subscribe((logged: NotifyMsg) => {
                vm.PeriodEnd = vm.globalCacheServices.getCurrentPeriod.TextDesc;
                    
            });
    }
    ngOnInit() {
       
        this.availLogEntries = [];
        this.PeriodEnd = this.globalCacheServices.getCurrentPeriod.TextDesc;
        this.chkBox1 = false;
        this.chkBox2 = false;
        this.chkBox3 = false;
        this.chkBox4 = false;
        this.chkBox5 = false;
        var vm = this;
        vm.StatusClass = '';
        this.loadMonthlyServices.getLogEntries()
           .subscribe(function (response: LoadMonthlyWrapper) {
               if (response.hasAnError)
               {
                 vm.JobStatus = response.errMessage;
                 vm.StatusClass = "statusErr";
               }
               else {
                console.log(response);
                vm.availLogEntries  = response.AvailLogEntries;
                var isodd: boolean = false;
                vm.JobStatus = response.message;
                vm.availLogEntries.forEach(function (item: LoadMonthlyItem){
                     item.IsOdd = isodd;
                     isodd =!isodd;
                });
               }
 
  
           })
    }
    ngOnDestroy() {
       
    }
    ImportFile(fileNo: number) {
        var vm = this;
        vm.StatusClass = '';
        this.loadMonthlyServices.loadMthlyFiles(fileNo)
          .subscribe(function (response: LoadMonthlyWrapper) {
              if (response.hasAnError)
              {
                vm.StatusClass = "statusErr";
                vm.JobStatus = response.errMessage;
              }
              else {
                if (response.FileImported) {
                    switch(fileNo)
                    {
                        case 1:
                            vm.chkBox1 = true;
                            break;
                            case 2:
                            vm.chkBox2 = true;
                            break;
                            case 3:
                            vm.chkBox3 = true;
                            break;
                            case 4:
                            vm.chkBox4 = true;
                            break;
                            case 5:
                            vm.chkBox5 = true;
                            break;
                    }
            }
        }
        });
    }

}