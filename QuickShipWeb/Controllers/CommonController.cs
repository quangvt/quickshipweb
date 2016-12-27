using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickShipWeb.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Accordion()
        {
            return View();
        }

        public ActionResult Carousel()
        {
            return View();
        }
    }
}