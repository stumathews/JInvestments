using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    public class FactorController : EntityManagedController<InvestmentInfluenceFactor>
    {
        public ActionResult Index()
        {            
            return View(EntityRepository.Entities.ToList());
        }

        public ActionResult IndexViewRaw()
        {
            // No layout stuff is wth view - maybe to embedded into another view
            // no head footer and css and javascript
            return PartialView("Index", EntityRepository.Entities.ToList());            
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
                EntityRepository.Entities.Add(factor);
                EntityRepository.SaveChanges();
                return RedirectToAction("Details", factor); 
            }
            catch
            {                
                return View(factor);
            }            
        }

        public ActionResult Details(int id)
        {
            return View(EntityRepository.Entities.Single(factor => factor.ID == id));
        }

        public ActionResult Api()
        {
            return Json(EntityRepository.Entities.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int ID)
        {
            var candidate = EntityRepository.Entities.Find(ID);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult Delete(Investment investment)
        {
            var candidate = EntityRepository.Entities.Find(investment.ID);
            EntityRepository.Entities.Remove(candidate);
            EntityRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}