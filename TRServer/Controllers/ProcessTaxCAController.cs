using System;
using System.Web.Http;
using System.Web.Http.Description;
using TRBusinessLayer.BusinessLayer;
using TRBusinessLayer.DataObjects;

namespace TRServer.Controllers
{
    [RoutePrefix("api/ProcessTaxCA")]
    public class ProcessTaxCAController : ApiController
    {
        [HttpGet]
        [Route("{periodId:int}")]
        [ResponseType(typeof(TaxWrapper))]
        public TaxWrapper GetCATaxForPeriod(int periodId)
        {
            Facade facade = new Facade();
            TaxWrapper taxWrapper = new TaxWrapper { hasAnError = true };
            taxWrapper = facade.GetRemCAForPeriod(periodId);
            taxWrapper.errMessage = "some type of message";
            return taxWrapper;
        }
        [HttpGet]
        [Route("{periodId:int}/{glCode}", Name = "GetTaxDetails")]
        [ResponseType(typeof(TaxWrapper))]
        public TaxWrapper GetTaxDetails(int periodId, string glCode)
        {
            Facade facade = new Facade();
            TaxWrapper taxWrapper = new TaxWrapper { hasAnError = true };
            taxWrapper = facade.GetTaxDetails(periodId, glCode);
            return taxWrapper;
        }
        [HttpGet]
        [Route("{periodId:int}/{glCode}/{dummy1:int}",Name = "GetTax502103")]
        [ResponseType(typeof(CarbonFuelTaxWrapper))]
        public CarbonFuelTaxWrapper GetTax502103(int periodId, string glCode,int dummy1)
        {
            Facade facade = new Facade();
            CarbonFuelTaxWrapper taxWrapper = new CarbonFuelTaxWrapper { hasAnError = false };
            taxWrapper = facade.GetTax502103(periodId, glCode);
            return taxWrapper;
        }
    }
}