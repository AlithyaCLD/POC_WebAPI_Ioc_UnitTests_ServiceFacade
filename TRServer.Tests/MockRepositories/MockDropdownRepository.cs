using System.Collections.Generic;
using TR.DataLayer.Interfaces.Repositories;
using TRBusinessLayer.DataObjects;

namespace TRServer.Tests.MockRepositories
{
    public class MockDropdownRepository : IDropdownRepository
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
            List<DropDownItem> testData = new List<DropDownItem>();
            testData.Add(new DropDownItem { Text = "01/2009", Value = "01/2009" });
            testData.Add(new DropDownItem { Text = "02/2009", Value = "02/2009" });
            return testData;
        }
    }
}
