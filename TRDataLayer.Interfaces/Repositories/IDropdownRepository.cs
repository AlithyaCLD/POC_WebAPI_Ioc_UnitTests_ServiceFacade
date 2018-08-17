using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRBusinessLayer.DataObjects;

namespace TRDataLayer.Interfaces.Repositories
{
    public interface IDropdownRepository
    {
        List<DropDownItem> GetAvailVauchers();
        List<DropDownItem> GetAvailTaxTypes();

        List<DropDownItem> GetPeriods();
    }
}
