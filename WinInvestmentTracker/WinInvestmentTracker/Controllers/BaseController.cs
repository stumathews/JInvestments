using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WinInvestmentTracker.Controllers
{
    /// <summary>
    /// This will house common functionlaity that all controllers will want access to.
    /// This includes logging functionality
    /// </summary>
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}