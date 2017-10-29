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
            
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Factors", createActionControllerName:"Factor", createActionName: "Create", redirectToControllerName:"Investment", redirectToAction:"SelectFactors");
            return View("SelectItems", checkModels);
        }

        /// <summary>
        /// Provides a new action URL in Viewbag.ActionUrl that SelectItems view pulls out and exposes
        /// This is used so that we can use the same generic SelectItems view and CheckmModels but
        /// customize it depending on the underlying type of items the select items view is showing.
        /// We usually want a 'Create' button at the bottom, going to the Create action of the underlying type that we are
        /// selecting so that we can create a new one and when we are done we want to be redirected back to where we started after the
        /// 'Create' action is done for that item but by default the create action redirects to 'Details'. Here we can ovveride that.
        /// </summary>
        /// <param name="checkItemsViewTitle"></param>
        /// <param name="createActionControllerName"></param>
        /// <param name="createActionName"></param>
        /// <param name="redirectToControllerName"></param>
        /// <param name="redirectToAction"></param>
        private void AddCustomCreateAndCustomCreateRedirect(string checkItemsViewTitle, string createActionControllerName, string createActionName, string redirectToControllerName, string redirectToAction)
        {
            ViewBag.Title = checkItemsViewTitle;
            ViewBag.CustomActionUrl = Url.Action(createActionName, createActionControllerName, null, null);
            ViewBag.CustomActionName = "Create new " + createActionControllerName.ToLower();

            // This will force any Create actions to go to the following controller/action instead.
            OverrideCreateActionRedirect(redirectToControllerName, redirectToAction);
        }

        /// <summary>
        /// "Create" actions usually redirect to the "Details" page unless we say otherwise here
        /// </summary>
        /// <param name="returnControllerName">controller to redirect to</param>
        /// <param name="returnAction">action in controller to redirect to</param>
        private void OverrideCreateActionRedirect(string returnControllerName, string returnAction)
        {
            TempData["ReturnAction"] = returnAction;
            TempData["ReturnController"] = returnControllerName;
        }

        [HttpPost]
        [ClearCustomRedirects]
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
            
            AddCustomCreateAndCustomCreateRedirect( checkItemsViewTitle: "Risks",  createActionControllerName: "Risk", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "SelectRisks");
            return View("SelectItems",checkModels);
        }

        [HttpPost]
        [ClearCustomRedirects]
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
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Regions", createActionControllerName: "Region", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "SelectRegions");            
            return View("SelectItems", checkModels);
        }

        [HttpPost]
        [ClearCustomRedirects]
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
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Groups", createActionControllerName: "Group", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "SelectGroups");
            return View("SelectItems", checkModels);
        }

        [HttpPost]
        [ClearCustomRedirects]
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