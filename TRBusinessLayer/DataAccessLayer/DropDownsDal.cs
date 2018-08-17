using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.Interfaces;

namespace TRBusinessLayer.DataAccessLayer
{
    public class DropDownsDal : IDropDownsDal
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

  
    
    }
}
