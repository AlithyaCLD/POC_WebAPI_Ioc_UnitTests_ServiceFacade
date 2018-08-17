using System.Collections.Generic;
using TRBusinessLayer.DataObjects;

namespace TRBusinessLayer.Interfaces
{
    public interface ITaxCadDal
    {
        List<TaxRemCA> GetCATaxForPeriod(int periodId);
        List<TaxItem> GetTax502009(int periodId, string glCode);
    }
}
