using System;
using System.Linq;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.DataAccessLayer;


namespace TRBusinessLayer.Process
{
    public class GetTaxAmountRpt
    {
        public TaxReportWrapper GetTaxAmtRpt(int languageId,DateTime? fromPeriodEnd) 
        {
            TaxReportWrapper taxReportWrapper = new TaxReportWrapper { hasAnError = false };
          
            AccountingPeriodDal importLoggingDal = new AccountingPeriodDal();
            taxReportWrapper.AvailStartPeriod = importLoggingDal.GetAvailStartPeriods(fromPeriodEnd).ToList();
            taxReportWrapper.AvailEndPeriod = importLoggingDal.GetAvailEndPeriods(fromPeriodEnd).ToList();
            DropDownsDal genericDal = new DropDownsDal();
            taxReportWrapper.AvailTaxTypes = genericDal.GetAvailTaxTypes();
            taxReportWrapper.AvailVoucherId = genericDal.GetAvailVauchers();
            return taxReportWrapper;
        }
     
    }
}