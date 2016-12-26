using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuickShipWeb.Models;
using PagedList;

namespace QuickShipWeb.Controllers
{
    public class MST_CUSTOMERController : Controller
    {
        private CodeFirstDBContext db = new CodeFirstDBContext();

        //// GET: MST_CUSTOMER
        //public ActionResult Index()
        //{
        //    return View(db.MST_CUSTOMER.ToList());
        //}

        //public ActionResult Index(int? page)
        //{
        //    var models = db.MST_CUSTOMER.OrderBy(p => p.Name);
        //    int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(models.ToPagedList(pageNumber, pageSize));
        //}

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "cust_name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            } else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var customer = from c in db.MST_CUSTOMER
                           select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customer = customer.Where(c => c.Name.Contains(searchString)
                || c.Code.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "cust_name_desc":
                    customer = customer.OrderByDescending(c => c.Name);
                    break;
                default:
                    customer = customer.OrderBy(c => c.Code);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(customer.ToPagedList(pageNumber, pageSize));
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
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MST_CUSTOMER mST_CUSTOMER = db.MST_CUSTOMER.Find(id);
        //    if (mST_CUSTOMER == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mST_CUSTOMER);
        //}

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
            ViewBag.ZoneId = new SelectList(db.MST_ZONE, "Id", "Name", 
                mST_CUSTOMER.ZoneId);
            ViewBag.RegionId = new SelectList(db.MST_REGION.
                Where(t => t.ZoneId == mST_CUSTOMER.ZoneId), "Id", "Name",
                mST_CUSTOMER.RegionId);
            return View(mST_CUSTOMER);
        }

        // POST: MST_CUSTOMER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MST_CUSTOMER mST_CUSTOMER)
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

        public PartialViewResult Regions(int zoneId)
        {
            ViewBag.RegionId = new SelectList(db.MST_REGION.
                Where(t => t.ZoneId == zoneId), "Id", "Name");
            return PartialView();
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
