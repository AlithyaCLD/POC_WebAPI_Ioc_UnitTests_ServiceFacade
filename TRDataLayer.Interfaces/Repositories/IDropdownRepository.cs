using System.Collections.Generic;
using TRBusinessLayer.DataObjects;

namespace TR.DataLayer.Interfaces.Repositories
{
    public interface IDropdownRepository
    {
        List<DropDownItem> GetAvailVauchers();
        List<DropDownItem> GetAvailTaxTypes();
        List<DropDownItem> GetPeriods();
    }
}
