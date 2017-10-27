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
    public class InvestmentController : EntityManagedController<Investment>
    {
        public ActionResult Index()
        {
            var investments = EntityRepository.Entities.ToList();
            return View(investments);
        }
        public ActionResult Api()
        {
            return Json(EntityRepository.Entities.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int ID)
        {
            var candidate = EntityRepository.Entities.Single(o => o.ID == ID);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult Delete(Investment investment)
        {
            var candidate = EntityRepository.Entities.Single(o => o.ID == investment.ID);
            EntityRepository.Entities.Remove(candidate);
            EntityRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Investment investment)
        {
            try
            {
                EntityRepository.Entities.Add(investment);
                EntityRepository.SaveChanges();
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
            return View(EntityRepository.Entities.SingleOrDefault(investment => investment.ID == id));
        }

        public ActionResult InvestmentByRisk(int id)
        {
            
            var risk = EntityRepository.GetEntityByType<InvestmentRisk>().SingleOrDefault(r => r.ID == id);
            var risks = risk.Investments;
            ViewBag.ExtraTitle = string.Format("By Investment Risk: {0}", risk.Name);
            return View("Index", risks);
        }

        public ActionResult InvestmentByFactor(int id)
        {
            return View("Index", EntityRepository.GetEntityByType<InvestmentInfluenceFactor>().SingleOrDefault(x => x.ID == id).Investments);
        }

        public ActionResult InvestmentByGroup(int id)
        {
            return View("Index", EntityRepository.GetEntityByType<InvestmentGroup>().SingleOrDefault(x => x.ID == id).Investments);
        }

        public ActionResult InvestmentByRegion(int id)
        {
            return View("Index", EntityRepository.GetEntityByType<Region>().SingleOrDefault(x => x.ID == id).Investments);
        }
    }
}