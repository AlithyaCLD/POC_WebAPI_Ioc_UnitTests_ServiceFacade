using System;
using System.Web.Http;
using System.Web.Http.Description;

using TRBusinessLayer.BusinessLayer;
using TRBusinessLayer.DataObjects;

namespace TRServer.Controllers
{
    [RoutePrefix("api/TaxAmountRpt")]
    public class TaxAmountRptController : BaseController
    {
        [HttpGet]
        [Route("{fromPeriodEnd}")]
        [ResponseType(typeof(TaxReportWrapper))]

        public TaxReportWrapper GetTaxAmtRpt(DateTime? fromPeriodEnd)
        {
            Facade facade = new Facade();
            TaxReportWrapper taxReportWrapper = new TaxReportWrapper { hasAnError = false};
            try
            {
                int languageId = 1;
                return facade.GetTaxAmtRpt(languageId, fromPeriodEnd);
            }
            catch (Exception ex)
            {
                taxReportWrapper.errMessage = GetAdminMsg;
                taxReportWrapper.hasAnError = true;
                logger.Error("GetDropDowns: " + ex.Message);
                logger.Error("GetDropDowns: " + ex.StackTrace);
                return taxReportWrapper;
            }
        }

    }
}