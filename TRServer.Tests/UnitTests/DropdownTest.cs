using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRServer.Controllers;
using TR.DataLayer.Interfaces.Repositories;
using TRServer.Tests.MockRepositories;
using TRBusinessLayer.DataObjects;
using TR.BusinessLayer.Process;
using TR.ServiceLayer.Interfaces.Generic;
using TR.DataLayer.Interfaces.Generic;
using Moq;

namespace TRServer.Tests
{
    [TestClass]
    public class DropdownTest
    {
        private Mock<IRepository<DropDownItem>> _dropDownRepository;
        private IDropDownService _dropDownService;

        [TestInitialize]
        public void Initialize()
        {
            _dropDownRepository = new Mock<IRepository<DropDownItem>>();
            _dropDownService = new DropDownService(_dropDownRepository.Object);
        }


        //[TestMethod]
        //public void can_generate_monthly_periods_from_service()
        //{
        //    var monthlyPeriods = _dropDownService.GetMonthlyPeriods();

        //    Assert.AreEqual("01/2009", monthlyPeriods[0].Text);
        //}

        [TestMethod]
        public void can_generate_monthly_periods_from_controller()
        {
            IDropdownRepository repository = new MockDropdownRepository();
            DropdownsController controller = new DropdownsController(repository);

            JsonResult<List<DropDownItem>> result = controller.GetPeriods() as JsonResult<List<DropDownItem>>;

            Assert.IsNotNull(result.Content);
            Assert.AreNotEqual(0, result.Content.Count);
            Assert.AreEqual("01/2009", result.Content[0].Text);
        }
    }
}
