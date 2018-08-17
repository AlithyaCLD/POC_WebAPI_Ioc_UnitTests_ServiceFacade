using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRServer.Controllers;
using TRDataLayer.Interfaces.Repositories;
using TRServer.Tests.MockRepositories;
using TRBusinessLayer.DataObjects;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;

namespace TRServer.Tests
{
    [TestClass]
    public class DropdownTest
    {
        [TestMethod]
        public void GetDropDowns_CheckCount()
        {
            IDropdownRepository repository = new MockDropdownRepository();
            DropdownsController controller = new DropdownsController(repository);

            JsonResult<List<DropDownItem>> result = controller.GetPeriods() as JsonResult<List<DropDownItem>>;
           
            Assert.IsNotNull(result.Content);
            Assert.AreNotEqual(0, result.Content.Count);
            Assert.AreEqual("01/2009", result.Content[0].TextDesc);
        }
    }
}
