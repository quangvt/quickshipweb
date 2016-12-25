using QuickShipWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickShipWeb.Controllers
{
    public class SearchController : Controller
    {
        private CodeFirstDBContext db = new CodeFirstDBContext();

        [HttpPost]
        public ActionResult Index(string searchquery, string fromcontroller)
        {
            switch (fromcontroller)
            {
                case "MST_CUSTOMER":
                    return RedirectToAction("SearchCustomersResult", new { query = searchquery });
                case "MST_LOCATION":
                    return RedirectToAction("SearchLocationResult", new { query = searchquery });
            }
            return View();
        }

        public ActionResult SearchCustomersResult(string query)
        {
            ViewBag.SearchQuery = query;
            var results = db.MST_CUSTOMER.Where(p => p.Name.Contains(query)
            || p.Email.Contains(query)
            || p.Description.Contains(query)).ToList();
            return View(results);
        }

        public ActionResult SearchLocationsResult(string query)
        {
            ViewBag.SearchQuery = query;
            var results = db.MST_LOCATION.Where(p => p.Name.Contains(query)
            || p.Description.Contains(query)).ToList();
            return View(results);
        }
    }
}
