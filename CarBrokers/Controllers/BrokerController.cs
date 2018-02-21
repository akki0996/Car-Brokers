using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarBrokers.Controllers {
    public class BrokerController : Controller {
        // GET: CarBroker
        public ActionResult Index() {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}