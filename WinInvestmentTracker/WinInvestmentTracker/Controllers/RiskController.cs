using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    public class RiskController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {            
            return View(db.Risks.ToList());
        }

        // MVC 5 allows this as well as routesconfig class
        [Route("risk/create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}