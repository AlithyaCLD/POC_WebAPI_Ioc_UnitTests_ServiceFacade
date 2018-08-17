using System;
using System.Collections.Generic;
using System.Linq;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.DataAccessLayer;
using TRBusinessLayer.Interfaces;

namespace TRBusinessLayer.Process
{
    public class DropDowns  
    {
        // Only as a sample code. Must be refactored for unit test
        // Also there will be many different type of data that will populate dropdowns
        public DropDownsWrapper GetGenericDropDown(string typeOfData, DateTime? fromPeriod)
        {
             
            DropDownsWrapper dropDownsWrapper = new DropDownsWrapper { hasAnError = false };
                  
            switch (typeOfData)
            {
                case "AVAILPERIODS":
                    AccountingPeriodDal accountingPeriodDal = new AccountingPeriodDal();
                    dropDownsWrapper = new DropDownsWrapper { hasAnError = false };
                    dropDownsWrapper.AvailDropDownItems = accountingPeriodDal.GetAvailPeriods(fromPeriod).ToList();
                    break;
                //case Constants.StartPeriods:                                         
                //    genericWrapperDto = new GenericWrapperDto { HasAnError = false };
                //    genericWrapperDto.AvailDropDownItems = accountingPeriodDal.GetAvailStartPeriods(fromDate).ToList();
                //    break;
                //case Constants.EndPeriods:
                //    genericWrapperDto = new GenericWrapperDto { HasAnError = false };
                //    genericWrapperDto.AvailDropDownItems = accountingPeriodDal.GetAvailEndPeriods(fromDate).ToList();
                //    break;
                //case Constants.TaxType:
                //    var GenericDal1 = new GenericDal();
                //    genericWrapperDto = new GenericWrapperDto { HasAnError = false };
                //    genericWrapperDto.AvailDropDownItems = GenericDal1.GetAvailTaxTypes().ToList();
                //    break;
                //case Constants.Vaucher:
                //    var GenericDal2 = new GenericDal();
                //    genericWrapperDto = new GenericWrapperDto { HasAnError = false };
                //    genericWrapperDto.AvailDropDownItems = GenericDal2.GetAvailVauchers().ToList();
                //    break;
                default:
                    dropDownsWrapper.AvailDropDownItems = new List<DropDownItem>();
                    break;

            }
  
            return dropDownsWrapper;
        }
      
    }
}