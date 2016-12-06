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
    public class MST_CUSTOMERController : Controller
    {
        private CodeFirstDBContext db = new CodeFirstDBContext();

        // GET: MST_CUSTOMER
        public ActionResult Index()
        {
            return View(db.MST_CUSTOMER.ToList());
        }

        // GET: MST_CUSTOMER/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MST_CUSTOMER mST_CUSTOMER = db.MST_CUSTOMER.Find(id);
            if (mST_CUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(mST_CUSTOMER);
        }

        // GET: MST_CUSTOMER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MST_CUSTOMER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Code,Name,Address,PIC,Phone,Email,IsActive,Description,Created_By,Created_Date,Modified_By,Modified_Date")] MST_CUSTOMER mST_CUSTOMER)
        //public ActionResult Create([Bind(Include = "Code,Name,Address,PIC,Phone,Email,Description")] MST_CUSTOMER mST_CUSTOMER)
        public ActionResult Create(MST_CUSTOMER mST_CUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.MST_CUSTOMER.Add(mST_CUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mST_CUSTOMER);
        }

        // GET: MST_CUSTOMER/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MST_CUSTOMER mST_CUSTOMER = db.MST_CUSTOMER.Find(id);
            if (mST_CUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(mST_CUSTOMER);
        }

        // POST: MST_CUSTOMER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Address,PIC,Phone,Email,IsActive,Description,Created_By,Created_Date,Modified_By,Modified_Date")] MST_CUSTOMER mST_CUSTOMER)
        {
            if (ModelState.IsValid)
            {
                mST_CUSTOMER.Modified_By = "updater";
                mST_CUSTOMER.Modified_Date = DateTime.Now;
                db.Entry(mST_CUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mST_CUSTOMER);
        }

        // GET: MST_CUSTOMER/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MST_CUSTOMER mST_CUSTOMER = db.MST_CUSTOMER.Find(id);
            if (mST_CUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(mST_CUSTOMER);
        }

        // POST: MST_CUSTOMER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MST_CUSTOMER mST_CUSTOMER = db.MST_CUSTOMER.Find(id);
            db.MST_CUSTOMER.Remove(mST_CUSTOMER);
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
