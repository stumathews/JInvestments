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