using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    public class InvestmentController : Controller
    {
        // Access to our database
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            var investments = db.Investments.ToList();
            return View(investments);
        }
        public ActionResult Api()
        {
            return Content("No API yet");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Investment investment)
        {
            try
            {
                //TODO: persit to database!
                db.Investments.Add(investment);
                db.SaveChanges();
                return View("Details", investment);
            }
            catch
            {
                return View();
            }            
        }

        [RunThisAfterActionComplete]        
        public ActionResult Details(int id)
        {            
            return View(db.Investments.SingleOrDefault(investment => investment.ID == id));
        }
        
    }
}