using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRBusinessLayer.DataObjects;

namespace TRBusinessLayer.Interfaces
{
    public interface IAccountingPeriodDal
    {
        List<DropDownItem> GetAvailPeriods(DateTime? fromDate);
  
        List<DropDownItem> GetAvailStartPeriods(DateTime? fromDate);
  
        List<DropDownItem> GetAvailEndPeriods(DateTime? fromDate);
   
    }

}
