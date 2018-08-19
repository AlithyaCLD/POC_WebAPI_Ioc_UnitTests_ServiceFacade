using System.Collections.Generic;
using TRBusinessLayer.DataObjects;

namespace TR.ServiceLayer.Interfaces.Generic
{
    public interface IDropDownService : IService<DropDownItem>
    {
        IList<DropDownItem> GetMonthlyPeriods();
    }
}
