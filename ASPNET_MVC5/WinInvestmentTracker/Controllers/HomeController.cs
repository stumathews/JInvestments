using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    [GlobalLogging]
    public class HomeController : Controller
    {
        // GET: /home/index
        public ActionResult Index()
        {
            return View(); // look for a view whos name matches matches the method
        }

        // GET: /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application Description page.s";

            return View();
        }

        // GET: /home/contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Foo()
        {
            return View("Contact");
        }
    }
}