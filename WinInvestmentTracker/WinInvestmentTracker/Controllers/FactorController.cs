using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    public class FactorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {            
            return View(db.Factors.ToList());
        }

        public ActionResult IndexViewRaw()
        {
            // No layout stuff is wth view - maybe to embedded into another view
            // no head footer and css and javascript
            return PartialView("Index", db.Factors.ToList());            
        }

        // GET(default): Request a create action to present them a form
        public ActionResult Create()
        {
            return View();
        }

        // Create a new Investment
        [HttpPost]
        public ActionResult Create(InvestmentInfluenceFactor factor)
        {
            try
            {
                db.Factors.Add(factor);
                db.SaveChanges();
                return RedirectToAction("Details", factor); 
            }
            catch
            {                
                return View(factor);
            }            
        }

        public ActionResult Details(int id)
        {
            return View(db.Factors.Single(factor => factor.ID == id));
        }

        public ActionResult TryJson()
        {
            // No layout stuff is applied.
            return Json(db.Factors.ToList(), JsonRequestBehavior.AllowGet);
            //TODO: Look at the ActionResult types on the MSDN docs
        }
    }
}