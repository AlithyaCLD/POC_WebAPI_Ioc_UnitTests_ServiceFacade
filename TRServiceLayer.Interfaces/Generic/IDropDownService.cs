using System.Collections.Generic;
using TR.BusinessLayer.Domain.Common;

namespace TR.ServiceLayer.Interfaces.Generic
{
    public interface IDropDownService : IService<TextValue>
    {
        IList<TextValue> GetMonthlyPeriods();
    }
}
