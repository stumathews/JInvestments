using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
            return Json(db.Investments.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int ID)
        {
            var candidate = db.Investments.Single(o => o.ID == ID);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult Delete(Investment investment)
        {
            var candidate = db.Investments.Single(o => o.ID == investment.ID);
            db.Investments.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
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

        public ActionResult InvestmentByRisk(int id)
        {
            var risk = db.Risks.SingleOrDefault(r => r.ID == id);
            var risks = risk.Investments;
            ViewBag.ExtraTitle = string.Format("By Investment Risk: {0}", risk.Name);
            return View("Index", risks);
        }

        public ActionResult InvestmentByFactor(int id)
        {
            return View("Index", db.Factors.SingleOrDefault(x => x.ID == id).Investments);
        }

        public ActionResult InvestmentByGroup(int id)
        {
            return View("Index", db.Groups.SingleOrDefault(x => x.ID == id).Investments);
        }

        public ActionResult InvestmentByRegion(int id)
        {
            return View("Index", db.Regions.SingleOrDefault(x => x.ID == id).Investments);
        }

        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {            
            var candidate = db.Investments.Find(pk);
            WinInvestmentTracker.Common.ReflectionUtilities.SetPropertyValue(candidate, name, value);
            db.SaveChanges();   

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        

    }
}