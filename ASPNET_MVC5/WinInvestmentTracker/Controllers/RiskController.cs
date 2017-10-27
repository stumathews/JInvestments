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
    public class RiskController : EntityManagedController<Models.InvestmentRisk>
    {
        public ActionResult Index()
        {            
            return View(EntityRepository.Entities.ToList());
        }

        // MVC 5 allows this as well as routesconfig class
        [Route("risk/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvestmentRisk risk)
        {
            try
            {
                EntityRepository.Entities.Add(risk);
                EntityRepository.SaveChanges();
                return RedirectToAction("Details", risk);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(EntityRepository.Entities.SingleOrDefault(risk => risk.ID == id));
        }

        public ActionResult Api()
        {
            return Json(EntityRepository.Entities.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int ID)
        {
            var risk = EntityRepository.Entities.Find(ID);
            return View(risk);
        }
        [HttpPost]
        public ActionResult Delete(InvestmentRisk risk)
        {
            var candidate = EntityRepository.Entities.Find(risk.ID);
            EntityRepository.Entities.Remove(candidate);
            EntityRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {
            var candidate = EntityRepository.Entities.Find(pk);
            WinInvestmentTracker.Common.ReflectionUtilities.SetPropertyValue(candidate, name, value);
            EntityRepository.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }


    }
}