using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRServer.Controllers;
using TR.DataLayer.Interfaces.Repositories;
using TRServer.Tests.MockRepositories;
using TRBusinessLayer.DataObjects;
using System.Collections.Generic;
using System.Web.Http.Results;
using TR.ServiceLayer.Interfaces.Generic;
using TR.BusinessLayer.Domain.Common;
using TR.DataLayer.Interfaces.Generic;
using Moq;
using TR.BusinessLayer.Process;

namespace TRServer.Tests
{
    [TestClass]
    public class DropdownTest
    {
        private Mock<IRepository<TextValue>> _dropDownRepository;
        private IDropDownService _dropDownService;

        [TestInitialize]
        public void Initialize()
        {
            _dropDownRepository = new Mock<IRepository<TextValue>>();
            _dropDownService = new DropDownService(_dropDownRepository.Object);
        }

        [TestMethod]
        public void GetDropDowns_CheckCount()
        {
            IDropdownRepository repository = new MockDropdownRepository();
            //DropdownsController controller = new DropdownsController(repository);

            //JsonResult<List<DropDownItem>> result = controller.GetPeriods() as JsonResult<List<DropDownItem>>;
           
            //Assert.IsNotNull(result.Content);
            //Assert.AreNotEqual(0, result.Content.Count);
            //Assert.AreEqual("01/2009", result.Content[0].TextDesc);
        }
    }
}
