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

        public ActionResult Index()
        {
            ViewBag.Message = "Model View - Combine Multiple Model";

            CMB_DELIVERY_ORDER_PACKAGE cmb = GetDeliveryOrdersAndPackages();

            return View(cmb);
        }

        public ActionResult Index2()
        {
            ViewBag.Message = "Index2";

            CMB_DELIVERY_ORDER_PACKAGE cmb = GetDeliveryOrdersAndPackages();

            return View("Index2", cmb);
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

        // GET: SHP_DELIVERY_ORDER/DetailsViewModel/5
        public ActionResult DetailsViewModel(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMB_DELIVERY_ORDER_PACKAGE cmb = GetDeliveryOrderAndPackage(id);
            if (cmb == null)
            {
                return HttpNotFound();
            }
            return View(cmb);
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


        // GET: SHP_DELIVERY_ORDER/EditPackage/5
        public ActionResult EditPackage(long? id)
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
            ViewBag.Delivery_Order_Id = 
                new SelectList(db.SHP_DELIVERY_ORDER, "Id", "Delivery_Order", sHP_PACKAGE.Delivery_Order_Id);
            return View(sHP_PACKAGE);
        }

        // POST: SHP_DELIVERY_ORDER/EditPackage/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPackage([Bind(Include = "Id,Code,Name,Delivery_Order_Id,Status,Description,Created_By,Created_Date,Modified_By,Modified_Date")] SHP_PACKAGE sHP_PACKAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHP_PACKAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Delivery_Order_Id = 
                new SelectList(db.SHP_DELIVERY_ORDER, "Id", "Delivery_Order", sHP_PACKAGE.Delivery_Order_Id);
            return View(sHP_PACKAGE);
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

        // GET: SHP_DELIVERY_ORDER/Delete/5
        public ActionResult DeletePackage(long? id)
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

        // POST: SHP_DELIVERY_ORDER/Delete/5
        [HttpPost, ActionName("DeletePackage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePackageConfirmed(long id)
        {
            SHP_PACKAGE sHP_PACKAGE = db.SHP_PACKAGE.Find(id);
            db.SHP_PACKAGE.Remove(sHP_PACKAGE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Get Model View for Index View
        //     Combine of Delivery Orders and Packages
        private CMB_DELIVERY_ORDER_PACKAGE GetDeliveryOrdersAndPackages() {
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
        
        // Get Deliver Order and Package for Detail View
        private CMB_DELIVERY_ORDER_PACKAGE GetDeliveryOrderAndPackage(long? id) {
            CMB_DELIVERY_ORDER_PACKAGE cmb_package = new CMB_DELIVERY_ORDER_PACKAGE();
            
            // Add Delivery Order
            // Todo: Review this code
            List<SHP_DELIVERY_ORDER> del_order = new List<SHP_DELIVERY_ORDER>();
            del_order.Add(db.SHP_DELIVERY_ORDER.Find(id));
            cmb_package.Delivery_Orders = del_order;

            // Add Packages of Delivery Order
            List<SHP_PACKAGE> lst_packages = new List<SHP_PACKAGE>();

            lst_packages = (from b in db.SHP_PACKAGE
                            where b.Delivery_Order_Id == id
                            select b).ToList();
            cmb_package.Packages = lst_packages;

            return cmb_package;
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
