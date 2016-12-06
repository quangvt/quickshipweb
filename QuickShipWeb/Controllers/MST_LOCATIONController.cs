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
    public class MST_LOCATIONController : Controller
    {
        private CodeFirstDBContext db = new CodeFirstDBContext();

        // GET: MST_LOCATION
        public ActionResult Index()
        {
            return View(db.MST_LOCATION.ToList());
        }

        // GET: MST_LOCATION/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MST_LOCATION mST_LOCATION = db.MST_LOCATION.Find(id);
            if (mST_LOCATION == null)
            {
                return HttpNotFound();
            }
            return View(mST_LOCATION);
        }

        // GET: MST_LOCATION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MST_LOCATION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MST_LOCATION mST_LOCATION)
        {
            if (ModelState.IsValid)
            {
                db.MST_LOCATION.Add(mST_LOCATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mST_LOCATION);
        }

        // GET: MST_LOCATION/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MST_LOCATION mST_LOCATION = db.MST_LOCATION.Find(id);
            if (mST_LOCATION == null)
            {
                return HttpNotFound();
            }
            return View(mST_LOCATION);
        }

        // POST: MST_LOCATION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,IsActive,Description,Created_By,Created_Date,Modified_By,Modified_Date")] MST_LOCATION mST_LOCATION)
        {
            if (ModelState.IsValid)
            {
                mST_LOCATION.Modified_By = "updater";
                mST_LOCATION.Modified_Date = DateTime.Now;
                db.Entry(mST_LOCATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mST_LOCATION);
        }

        // GET: MST_LOCATION/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MST_LOCATION mST_LOCATION = db.MST_LOCATION.Find(id);
            if (mST_LOCATION == null)
            {
                return HttpNotFound();
            }
            return View(mST_LOCATION);
        }

        // POST: MST_LOCATION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MST_LOCATION mST_LOCATION = db.MST_LOCATION.Find(id);
            db.MST_LOCATION.Remove(mST_LOCATION);
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
