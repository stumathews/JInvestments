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

        public ActionResult SelectFactors()
        {
            var checkModels = EntityRepository.
                GetEntityByType<InvestmentInfluenceFactor>().
                Select(o => new CheckModel
                {
                    ID = o.ID,
                    Name = o.Name,
                    Checked = false
                }
            ).ToList();
            ViewBag.Title = "Factors";
            return View("SelectItems",checkModels);
        }

        [HttpPost]
        public ActionResult SelectFactors(List<CheckModel> checkModels)
        {
            TempData["factorIDs"] = checkModels.Where(o=>o.Checked).Select(o=>o.ID).ToArray();
            return RedirectToAction("SelectRisks");

        }

        public ActionResult SelectRisks()
        {
            var checkModels = EntityRepository.
               GetEntityByType<InvestmentRisk>().
               Select(o => new CheckModel
               {
                   ID = o.ID,
                   Name = o.Name,
                   Checked = false
               }
           ).ToList();
            ViewBag.Title = "Risks";
            return View("SelectItems",checkModels);
        }

        [HttpPost]
        public ActionResult SelectRisks(List<CheckModel> checkModels)
        {
            TempData["riskIDs"] = checkModels.Where(o => o.Checked).Select(o => o.ID).ToArray();
            return RedirectToAction("SelectRegions");
        }

        public ActionResult SelectRegions()
        {
            var checkModels = EntityRepository.
              GetEntityByType<Region>().
              Select(o => new CheckModel
              {
                  ID = o.ID,
                  Name = o.Name,
                  Checked = false
              }
          ).ToList();
            ViewBag.Title = "Regions";
            return View("SelectItems", checkModels);
        }

        [HttpPost]
        public ActionResult SelectRegions(List<CheckModel> checkModels)
        {
            TempData["regionIDs"] = checkModels.Where(o => o.Checked).Select(o => o.ID).ToArray();
            return RedirectToAction("SelectGroups");
        }

        public ActionResult SelectGroups()
        {
            var checkModels = EntityRepository.
              GetEntityByType<InvestmentGroup>().
              Select(o => new CheckModel
              {
                  ID = o.ID,
                  Name = o.Name,
                  Checked = false
              }
          ).ToList();
            ViewBag.Title = "Groups";
            return View("SelectItems", checkModels);
        }

        [HttpPost]
        public ActionResult SelectGroups(List<CheckModel> checkModels)
        {
            TempData["groupIDs"] = checkModels.Where(o => o.Checked).Select(o => o.ID).ToArray();
            return RedirectToAction("Summary");
        }

        public ActionResult Summary()
        {
            var investment = TempData.Peek("investment");
            return View(investment);
        }
        [HttpPost]
        public ActionResult Summary(string outcome)
        {
            if (outcome.Equals("Cancel"))
                return RedirectToAction("Index");
            var investment = (Investment)TempData["investment"];

            var factorIDs = (int[])TempData["factorIDs"];
            var factors = factorIDs.Select(f => EntityRepository.GetEntityByType<InvestmentInfluenceFactor>().Find(f));
            investment.Factors = factors.ToList();

            var risksIDs = (int[])TempData["riskIDs"];
            var risks = risksIDs.Select(r => EntityRepository.GetEntityByType<InvestmentRisk>().Find(r));
            investment.Risks = risks.ToList();

            var groupIDs = (int[])TempData["groupIDs"];
            var groups = groupIDs.Select(g => EntityRepository.GetEntityByType<InvestmentGroup>().Find(g));
            investment.Groups = groups.ToList();

            var regionIDs = (int[])TempData["regionIDs"];
            var regions = regionIDs.Select(g=> EntityRepository.GetEntityByType<Region>().Find(g));
            investment.Regions = regions.ToList();

            EntityRepository.Entities.Add(investment);
            EntityRepository.SaveChanges();


            return RedirectToAction("Details", investment);
        }

        [HttpPost]
        public override ActionResult Create(Investment entity)
        {
            try
            {
                TempData["investment"] = entity;
                return RedirectToAction("SelectFactors");
            }
            catch
            {
                return View(entity);
            }
        }


        public ActionResult InvestmentByRisk(int id)
        {
            var risk = EntityRepository.GetEntityByType<InvestmentRisk>().SingleOrDefault(r => r.ID == id);
            var risks = risk.Investments;
            ViewBag.ExtraTitle = $"By Investment Risk: {risk.Name}";
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