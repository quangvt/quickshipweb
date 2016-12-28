






using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Begin Add New
using QuickShipWeb.Models;
using QuickShipWeb.Infrastructure;
// End Add New

namespace QuickShipWeb.Controllers
{
    public class TestT4Controller : Controller
    {
		// Begin Add New
		private readonly ApplicationDbContext _context;
		private readonly ICurrentUser _currentUser;

		public TestT4Controller(ApplicationDbContext context,
		ICurrentUser currentUser)
		{
			_context = context;
			_currentUser = currentUser;
		}
		// End Add New

        // GET: TestT4
        public ActionResult Index()
        {
            return View();
        }
    }
}