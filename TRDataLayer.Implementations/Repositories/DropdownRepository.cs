using System.Collections.Generic;
using System.Linq;
using TR.BusinessLayer.Entities;
using TR.DataLayer.Interfaces.Repositories;
using TRBusinessLayer.DataObjects;

namespace TRDataLayer.Implementations.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        public List<DropDownItem> GetAvailTaxTypes()
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { Text = "TPS", Value = "1" });
            testData.Add(new DropDownItem { Text = "TVQ", Value = "2" });
            return testData;
        }

        public List<DropDownItem> GetAvailVauchers()
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { Text = "001", Value = "1" });
            testData.Add(new DropDownItem { Text = "002", Value = "2" });
            testData.Add(new DropDownItem { Text = "003", Value = "3" });
            testData.Add(new DropDownItem { Text = "004", Value = "4" });
            return testData;
        }

        public List<DropDownItem> GetPeriods()
        {
            TAXREMITTANCESEntities dbContext = new TAXREMITTANCESEntities();
            List<DropDownItem> items = new List<DropDownItem>();
            dbContext.tblTax_Process.AsNoTracking().Select(x => x.MonthYear).Distinct().ToList().ForEach(x => items.Add(new DropDownItem(){ Text = x , Value = x}));

            return items;
        }
    }
}
