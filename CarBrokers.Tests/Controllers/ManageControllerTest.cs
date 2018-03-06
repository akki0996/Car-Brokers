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
    public class ManageControllerTest
    {
        [TestMethod]
        public void AddPhoneNumber()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = controller.AddPhoneNumber() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChangePassword()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = controller.ChangePassword() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
