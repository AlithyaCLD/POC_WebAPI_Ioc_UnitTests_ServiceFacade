using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRBusinessLayer.DataObjects;
using TRDataLayer.Interfaces.Repositories;
using TREntityModel;

namespace TRDataLayer.Implementations.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        public List<DropDownItem> GetAvailTaxTypes()
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { TextDesc = "TPS", ValueId = "1" });
            testData.Add(new DropDownItem { TextDesc = "TVQ", ValueId = "2" });
            return testData;
        }

        public List<DropDownItem> GetAvailVauchers()
        {
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { TextDesc = "001", ValueId = "1" });
            testData.Add(new DropDownItem { TextDesc = "002", ValueId = "2" });
            testData.Add(new DropDownItem { TextDesc = "003", ValueId = "3" });
            testData.Add(new DropDownItem { TextDesc = "004", ValueId = "4" });
            return testData;
        }

        public List<DropDownItem> GetPeriods()
        {
            TAXREMITTANCESEntities dbContext = new TAXREMITTANCESEntities();
            List<DropDownItem> items = new List<DropDownItem>();
            dbContext.tblTax_Process.AsNoTracking().Select(x => x.MonthYear).Distinct().ToList().ForEach(x => items.Add(new DropDownItem(){ TextDesc = x , ValueId = x}));

            return items;
        }
    }
}
