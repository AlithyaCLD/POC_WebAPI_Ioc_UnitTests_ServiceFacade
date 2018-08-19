using System;
using System.Web.Http;
using System.Web.Http.Description;
using TR.BusinessLayer.Domain.Common;
using TR.DataLayer.Interfaces.Generic;
using TR.DataLayer.Interfaces.Repositories;
using TRBusinessLayer.DataObjects;

namespace TRServer.Controllers
{
    [RoutePrefix("api/Dropdowns")]   // AVAILPERIODS
    public class DropdownsController : ApiController
    {
        private IRepository<TextValue> _repository;
        private IDropdownRepository _dropdownRepository;
        private readonly IFacade _facade;

       

        public DropdownsController(IDropdownRepository dropdownRepository)
        {
            _dropdownRepository = dropdownRepository;
        }

        //public DropdownsController(IFacade facade)
        //{
        //    _facade = facade;
        //}

        //public DropdownsController(IRepository<TextValue> repository)
        //{
        //    _repository = repository;
        //}

        [Route("{Periods}")]
        public IHttpActionResult GetPeriods()
        {
            // return Json(this._facade.MonthlyPeriodService.GetMonthlyPeriods());
                        
            return Json(this._dropdownRepository.GetPeriods());
        }
    }
}