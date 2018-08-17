using System.Collections.Generic;
using TRBusinessLayer.DataObjects;

namespace TRBusinessLayer.Interfaces
{
    public interface IDropDownsDal
    {
        List<DropDownItem> GetAvailTaxTypes();
        List<DropDownItem> GetAvailVauchers();
    }
}
