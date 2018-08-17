using System;
using System.Web.Http;
using System.Web.Http.Description;

using TRBusinessLayer.BusinessLayer;
using TRBusinessLayer.DataObjects;
using TRDataLayer.Interfaces.Repositories;

namespace TRServer.Controllers
{
    [RoutePrefix("api/Dropdowns")]   // AVAILPERIODS
    public class DropdownsController : BaseController
    {
        private IDropdownRepository _repository;

        public DropdownsController(IDropdownRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("{fromPeriodEnd}/{typeOfDropDown}")]
        [ResponseType(typeof(DropDownsWrapper))]

        public DropDownsWrapper GetDropDowns(string fromPeriodEnd,string typeOfDropDown)
        {

            var availTypes = this._repository.GetAvailTaxTypes();

            Facade facade = new Facade();
            
            try
            {
                var dt = ConvertToDateTime(fromPeriodEnd);
                return facade.GetGenericDropDown(typeOfDropDown, dt);
            }
            catch (Exception ex)
            {
                DropDownsWrapper dropDownsWrapper = new DropDownsWrapper { hasAnError = true };
                dropDownsWrapper.errMessage = GetAdminMsg;
                logger.Error("GetDropDowns: " + ex.Message);
                logger.Error("GetDropDowns: " + ex.StackTrace);
                return dropDownsWrapper;
            }
        }

        [Route("{Periods}")]
        public IHttpActionResult GetPeriods()
        {
            return Json(this._repository.GetPeriods());
        }
    }
}