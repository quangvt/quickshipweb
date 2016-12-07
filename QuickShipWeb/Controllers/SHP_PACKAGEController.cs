using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuickShipWeb.Models;

namespace QuickShipWeb.Controllers
{
    public class SHP_PACKAGEController : Controller
    {
        private CodeFirstDBContext db = new CodeFirstDBContext();

        // GET: SHP_PACKAGE
        public ActionResult Index()
        {
            var sHP_PACKAGE = db.SHP_PACKAGE.Include(s => s.SHP_DELIVERY_ORDER);
            return View(sHP_PACKAGE.ToList());
        }

        // GET: SHP_PACKAGE/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHP_PACKAGE sHP_PACKAGE = db.SHP_PACKAGE.Find(id);
            if (sHP_PACKAGE == null)
            {
                return HttpNotFound();
            }
            return View(sHP_PACKAGE);
        }

        // GET: SHP_PACKAGE/Create
        public ActionResult Create()
        {
            ViewBag.Delivery_Order_Id = new SelectList(db.SHP_DELIVERY_ORDER, "Id", "Delivery_Order");
            return View();
        }

        // POST: SHP_PACKAGE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Delivery_Order_Id,Status,Description,Created_By,Created_Date,Modified_By,Modified_Date")] SHP_PACKAGE sHP_PACKAGE)
        {
            if (ModelState.IsValid)
            {
                db.SHP_PACKAGE.Add(sHP_PACKAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Delivery_Order_Id = new SelectList(db.SHP_DELIVERY_ORDER, "Id", "Delivery_Order", sHP_PACKAGE.Delivery_Order_Id);
            return View(sHP_PACKAGE);
        }

        // GET: SHP_PACKAGE/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHP_PACKAGE sHP_PACKAGE = db.SHP_PACKAGE.Find(id);
            if (sHP_PACKAGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Delivery_Order_Id = new SelectList(db.SHP_DELIVERY_ORDER, "Id", "Delivery_Order", sHP_PACKAGE.Delivery_Order_Id);
            return View(sHP_PACKAGE);
        }

        // POST: SHP_PACKAGE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Delivery_Order_Id,Status,Description,Created_By,Created_Date,Modified_By,Modified_Date")] SHP_PACKAGE sHP_PACKAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHP_PACKAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Delivery_Order_Id = new SelectList(db.SHP_DELIVERY_ORDER, "Id", "Delivery_Order", sHP_PACKAGE.Delivery_Order_Id);
            return View(sHP_PACKAGE);
        }

        // GET: SHP_PACKAGE/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHP_PACKAGE sHP_PACKAGE = db.SHP_PACKAGE.Find(id);
            if (sHP_PACKAGE == null)
            {
                return HttpNotFound();
            }
            return View(sHP_PACKAGE);
        }

        // POST: SHP_PACKAGE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SHP_PACKAGE sHP_PACKAGE = db.SHP_PACKAGE.Find(id);
            db.SHP_PACKAGE.Remove(sHP_PACKAGE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
