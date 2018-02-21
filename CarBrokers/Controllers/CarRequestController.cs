using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarBrokers.DAL;
using CarBrokers.Models;
using Microsoft.AspNet.Identity;

namespace CarBrokers.Controllers {
    public class CarRequestController : Controller {
        private CarBrokersContext db = new CarBrokersContext();

        // GET: CarRequest
        [Authorize(Roles = "Admin, Broker, Customer")]
        public ActionResult Index() {
            var carRequests = db.CarRequests.Include(c => c.ChooseCar);
            return View(carRequests.ToList());
        }

        // GET: CarRequest/Details/5
        [Authorize(Roles = "Admin, Broker, Customer")]
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRequest carRequest = db.CarRequests.Find(id);
            if (carRequest == null) {
                return HttpNotFound();
            }
            return View(carRequest);
        }

        // GET: CarRequest/Create
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Create() {
            ViewBag.CarID = new SelectList(db.Cars, "ID", "Make");
            return View();
        }

        // POST: CarRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Create([Bind(Include = "CarID, Price")] CarRequest carRequest) {
            carRequest.CustomerID = User.Identity.GetUserId();
            if (ModelState.IsValid) {
                db.CarRequests.Add(carRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "ID", "Make", carRequest.CarID);
            return View(carRequest);
        }

        // GET: CarRequest/Edit/5
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRequest carRequest = db.CarRequests.Find(id);
            if (carRequest == null) {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "Make", carRequest.CarID);
            return View(carRequest);
        }

        // POST: CarRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Edit([Bind(Include = "ID,CarID,Price,CustomerID,BrokerID")] CarRequest carRequest) {
            if (ModelState.IsValid) {
                db.Entry(carRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "Model", carRequest.CarID);
            return View(carRequest);
        }

        // GET: CarRequest/Delete/5
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRequest carRequest = db.CarRequests.Find(id);
            if (carRequest == null) {
                return HttpNotFound();
            }
            return View(carRequest);
        }

        // POST: CarRequest/Delete/5
        [Authorize(Roles = "Admin, Customer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            CarRequest carRequest = db.CarRequests.Find(id);
            db.CarRequests.Remove(carRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
