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
    }
}