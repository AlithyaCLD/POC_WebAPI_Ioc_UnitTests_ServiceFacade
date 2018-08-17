import { Component,OnInit, OnDestroy,ViewEncapsulation } from '@angular/core';
import { HttpClient }                                    from '@angular/common/http';

import { DropDownServices}          from './Shared/DropDownServices';
import { GlobalCacheServices}       from './Services/GlobalCacheServices';
import { DropDownsWrapper }         from './Entities/DropDownsWrapper';
import { DropDownItem }             from './Entities/DropDownItem';
import { NotifyMsg }                from './Entities/NotifyMsg';

import { ConstantsServices }        from './Services/ConstantsServices';
import { ChangeNotifyServices}      from './Services/ChangeNotifyServices';

import { environment }              from '../environments/environment';

//import { constants } from 'os';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  encapsulation: ViewEncapsulation.None
   
})

// To Execute: ng serve

export class AppComponent implements OnInit, OnDestroy {
  title = 'app';
  statusMessage;
  selectedPeriodId: number = 0;
  availPeriods : DropDownItem[];
  constructor(private http: HttpClient,
              private dropDownServices: DropDownServices,
              private changeNotifyServices: ChangeNotifyServices,
              private constantsServices: ConstantsServices,
              private globalCacheServices: GlobalCacheServices )
  {
    if (environment.production) {
  
      console.log('Productuction Mode');
    }
    else {
      console.log('Debug Mode'); 
    }
    this.globalCacheServices.setUrl = constantsServices.getCORSUrl;       
    this.dropDownServices.setHttp = this.http;
    this.dropDownServices.setUrl = constantsServices.getCORSUrl;
    var defPeriod = new DropDownItem();
    defPeriod.TextDesc = "99/9999";
    defPeriod.ValueId = -1;
    this.globalCacheServices.setCurrentPeriod = defPeriod
  }
  ngOnInit()
  {
    var vm = this;
    var dt: Date = new Date(2018,5,5);
    this.dropDownServices.getDropDownFrmDb(dt,'AVAILPERIODS')
       .subscribe(function (response: DropDownsWrapper) {
         if (!response.hasAnError) {
             vm.availPeriods = response.AvailDropDownItems;
         }
         else {
            vm.statusMessage= response.errMessage;
         }
       });
     
  }
  ngOnDestroy()
  {

  }
  onChangeChanged(newValue : number)
  {
      this.selectedPeriodId = newValue;
      var vm = this;
      var newPeriod = this.availPeriods.find(function (item: DropDownItem) {
          return (item.ValueId == vm.selectedPeriodId );
      });
      if (newPeriod != null) {
        vm.globalCacheServices.setCurrentPeriod = newPeriod;
        let notifyMsg = new NotifyMsg();
        notifyMsg.Period = newPeriod.TextDesc;
        notifyMsg.Reload = true;
        this.changeNotifyServices.setPeriodChanged(notifyMsg);
        // changeNotifyServices
      }
  }
}
