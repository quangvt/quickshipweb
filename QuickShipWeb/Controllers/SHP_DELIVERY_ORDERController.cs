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
    public class SHP_DELIVERY_ORDERController : Controller
    {
        private CodeFirstDBContext db = new CodeFirstDBContext();

        // GET: SHP_DELIVERY_ORDER
        public ActionResult Index()
        {
            return View(db.SHP_DELIVERY_ORDER.ToList());
        }

        public ActionResult IndexViewModel()
        {
            ViewBag.Message = "Model View - Combine Multiple Model";

            CMB_DELIVERY_ORDER_PACKAGE cmb = GetDeliveryOrderAndPackage();

            return View(cmb);
        }

        // GET: SHP_DELIVERY_ORDER/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHP_DELIVERY_ORDER sHP_DELIVERY_ORDER = db.SHP_DELIVERY_ORDER.Find(id);
            if (sHP_DELIVERY_ORDER == null)
            {
                return HttpNotFound();
            }
            return View(sHP_DELIVERY_ORDER);
        }

        // GET: SHP_DELIVERY_ORDER/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Code = new SelectList(db.MST_CUSTOMER, "Code", "Name");
            ViewBag.Location_Code = new SelectList(db.MST_LOCATION, "Code", "Name");
            return View();
        }

        // POST: SHP_DELIVERY_ORDER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SHP_DELIVERY_ORDER sHP_DELIVERY_ORDER)
        {
            if (ModelState.IsValid)
            {
                sHP_DELIVERY_ORDER.Status = 1; // Created New
                db.SHP_DELIVERY_ORDER.Add(sHP_DELIVERY_ORDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHP_DELIVERY_ORDER);
        }

        // GET: SHP_DELIVERY_ORDER/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHP_DELIVERY_ORDER sHP_DELIVERY_ORDER = db.SHP_DELIVERY_ORDER.Find(id);
            if (sHP_DELIVERY_ORDER == null)
            {
                return HttpNotFound();
            }
            return View(sHP_DELIVERY_ORDER);
        }

        // POST: SHP_DELIVERY_ORDER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Delivery_Order,Customer_Code,Location_Code,Create_Order_Date,Assign_Order_Date,Onroad_Order_Date,Finish_Order_Date,Begin_Amount,Final_Amount,Status,Unit,Description,Created_By,Created_Date,Modified_By,Modified_Date")] SHP_DELIVERY_ORDER sHP_DELIVERY_ORDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHP_DELIVERY_ORDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHP_DELIVERY_ORDER);
        }

        // GET: SHP_DELIVERY_ORDER/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHP_DELIVERY_ORDER sHP_DELIVERY_ORDER = db.SHP_DELIVERY_ORDER.Find(id);
            if (sHP_DELIVERY_ORDER == null)
            {
                return HttpNotFound();
            }
            return View(sHP_DELIVERY_ORDER);
        }

        // POST: SHP_DELIVERY_ORDER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SHP_DELIVERY_ORDER sHP_DELIVERY_ORDER = db.SHP_DELIVERY_ORDER.Find(id);
            db.SHP_DELIVERY_ORDER.Remove(sHP_DELIVERY_ORDER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private CMB_DELIVERY_ORDER_PACKAGE GetDeliveryOrderAndPackage() {
            CMB_DELIVERY_ORDER_PACKAGE cmb_pacakges = new CMB_DELIVERY_ORDER_PACKAGE();

            List<SHP_DELIVERY_ORDER> list_del_orders = db.SHP_DELIVERY_ORDER.ToList();

            cmb_pacakges.Delivery_Orders = list_del_orders;

            List<SHP_PACKAGE> list_packages = new List<SHP_PACKAGE>();

            foreach (SHP_DELIVERY_ORDER del_order in list_del_orders)
            {
                List<SHP_PACKAGE> lst = (from b in db.SHP_PACKAGE
                                        where b.Delivery_Order_Id == del_order.Id
                                        select b).ToList();
                list_packages.AddRange(lst);
            }

            cmb_pacakges.Packages = list_packages;

            return cmb_pacakges;
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
