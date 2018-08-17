using System;
using System.Collections.Generic;
using System.Linq;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.Process;

namespace TRBusinessLayer.BusinessLayer
{
    public class Facade
    {
        public Facade()
        {
 
        }
        #region Generic Methods
        public DropDownsWrapper GetGenericDropDown(string typeOfData,DateTime? fromPeriod)
        {
            var dropDowns = new DropDowns();
            return dropDowns.GetGenericDropDown(typeOfData, fromPeriod);
            
        }
        #endregion

        #region Generate Tax Amount Reports
        
        public TaxReportWrapper GetTaxAmtRpt(int languageId, DateTime? fromPeriodEnd)
        {
            var getTaxAmountRpt = new GetTaxAmountRpt();
            return getTaxAmountRpt.GetTaxAmtRpt(languageId, fromPeriodEnd);
        }

        #endregion

        #region Load Monthly methods (Logging of import/export files)
        public LoadMonthlyWrapper GetLogEntries()
        {
            var importLogging = new LoadMonthly();
            var results = importLogging.GetLogEntries();

            return results;
        }
        public LoadMonthlyWrapper ProcessMthlyLoad(int fileNo)
        {
            var importLogging = new LoadMonthly();
            var results = importLogging.ProcessMthlyLoad(fileNo);

            return results;

        }
        #endregion
        #region Tax Remittance CA
        public TaxWrapper GetRemCAForPeriod(int periodId)
        {
            var processTaxCA = new ProcessTaxCA();
            return processTaxCA.GetCATaxForPeriod(periodId);
        }
        public CarbonFuelTaxWrapper GetTax502103(int periodId, string glCode)
        {
            var processTaxCA = new ProcessTaxCA();
            switch (glCode)
            {
                case "502103A":
                    return processTaxCA.GetTax502103A(periodId, glCode);
                    //case "502103B":
                    //    return processTaxCA.GetTax502103B(periodId, glCode);
            }
            return new CarbonFuelTaxWrapper { hasAnError = true, message = "GL Code not Implemented" };
        }
        public TaxWrapper GetTaxDetails(int periodId, string glCode)
        {

            var processTaxCA = new ProcessTaxCA();
            switch (glCode)
            {
                case "502009":
                    return processTaxCA.GetTax502009(periodId, glCode);
                case "502563":
                    return processTaxCA.GetTax502563(periodId, glCode);
            }
            return new TaxWrapper { hasAnError = true, message = "GL Code not Implemented" };
        }
        #endregion

    }
}