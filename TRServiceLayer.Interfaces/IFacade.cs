﻿using TR.BusinessLayer.Domain.Common;
using TR.ServiceLayer.Interfaces.Generic;

namespace TR.ServiceLayer.Interfaces
{
    public interface IFacade
    {
        IDropDownService DropDownService { get; }
    }
}
