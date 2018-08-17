using System;
using System.Collections.Generic;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.Interfaces;

namespace TRBusinessLayer.DataAccessLayer
{
    public class AccountingPeriodDal : IAccountingPeriodDal
    {
        public List<DropDownItem> GetAvailPeriods(DateTime? fromDate)
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { TextDesc = "05/2018", ValueId = "1" });
            testData.Add(new DropDownItem { TextDesc = "06/2018", ValueId = "2" });
            testData.Add(new DropDownItem { TextDesc = "07/2018", ValueId = "3" });
            testData.Add(new DropDownItem { TextDesc = "08/2018", ValueId = "4" });
            testData.Add(new DropDownItem { TextDesc = "09/2018", ValueId = "5" });
            testData.Add(new DropDownItem { TextDesc = "10/2018", ValueId = "6" });
            return testData;
        }


        public List<DropDownItem> GetAvailStartPeriods(DateTime? fromDate)
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { TextDesc = "05/2018", ValueId = "1" });
            testData.Add(new DropDownItem { TextDesc = "06/2018", ValueId = "2" });
            testData.Add(new DropDownItem { TextDesc = "07/2018", ValueId = "3" });
            testData.Add(new DropDownItem { TextDesc = "08/2018", ValueId = "4" });
            testData.Add(new DropDownItem { TextDesc = "09/2018", ValueId = "5" });
            testData.Add(new DropDownItem { TextDesc = "10/2018", ValueId = "6" });
            return testData;
        }



        public List<DropDownItem> GetAvailEndPeriods(DateTime? fromDate)
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { TextDesc = "10/2018", ValueId = "1" });
            testData.Add(new DropDownItem { TextDesc = "11/2018", ValueId = "2" });
            testData.Add(new DropDownItem { TextDesc = "12/2018", ValueId = "3" });
            testData.Add(new DropDownItem { TextDesc = "01/2019", ValueId = "4" });
            testData.Add(new DropDownItem { TextDesc = "02/2019", ValueId = "5" });
            testData.Add(new DropDownItem { TextDesc = "03/2019", ValueId = "6" });
            return testData;
        }


 

    }
}