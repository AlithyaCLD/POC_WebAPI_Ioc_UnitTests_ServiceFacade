using System;
using System.Web.Http;
using System.Web.Http.Description;
using TR.DataLayer.Interfaces.Repositories;
using TRBusinessLayer.DataObjects;

namespace TRServer.Controllers
{
    [RoutePrefix("api/Dropdowns")]   // AVAILPERIODS
    public class DropdownsController : ApiController
    {
        private IDropdownRepository _repository;
        private readonly IFacade _facade;

        public DropdownsController(IFacade facade)
        {
            _facade = facade;
        }

        [Route("{Periods}")]
        public IHttpActionResult GetPeriods()
        {
            return Json(this._repository.GetPeriods());
        }
    }
}