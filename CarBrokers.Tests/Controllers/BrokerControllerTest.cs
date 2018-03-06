using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarBrokers;
using CarBrokers.Controllers;

namespace CarBrokers.Tests.Controllers
{
    [TestClass]
    public class BrokerControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            BrokerController controller = new BrokerController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
