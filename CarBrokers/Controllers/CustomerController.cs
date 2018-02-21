using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarBrokers.Controllers {
    public class CustomerController : Controller {
        // GET: Customer
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Index() {
            // open up the index page from home controller
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Car Requests
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult CarRequests() {
            return View();
        }

        // GET: Brokers List
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult BrokerList() {
            return View();
        }
    }
}