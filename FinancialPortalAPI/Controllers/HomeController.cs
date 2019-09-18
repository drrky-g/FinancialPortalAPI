using FinancialPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialPortalAPI.Controllers
{
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();
        public ActionResult Index()
        {
            var house = db.Households.FirstOrDefault();
            ViewBag.Title = "Home Page";

            return View(house);
        }
    }
}
