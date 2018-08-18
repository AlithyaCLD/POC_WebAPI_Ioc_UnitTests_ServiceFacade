using TR.BusinessLayer.Domain.Common;
using TR.ServiceLayer.Interfaces.Generic;

namespace TRServer.Controllers
{
    public interface IFacade
    {
        IDropDownService MonthlyPeriodService { get; }
    }
}