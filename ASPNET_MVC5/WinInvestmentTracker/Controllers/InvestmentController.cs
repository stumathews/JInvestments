﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.BOLO;

namespace WinInvestmentTracker.Controllers
{
    [GlobalLogging]
    public class InvestmentController : EntityManagedController<Investment>
    {

        public ActionResult GenerateFactorsGraph(int ID)
        {

            /*
               var data = {
                "nodes":[
                    { "name": "index", "value": 5},
                    { "name": "about", "value": 5},
                    { "name": "contact", "value": 5},
                    { "name": "store", "value": 8},
                    { "name": "cheese", "value": 8},
                    { "name": "yoghurt", "value": 10},
                    { "name": "milk", "value": 2}
                    ],
                    "links":[
                    {"source":0,"target":1,"value":25},
                    {"source":0,"target":2,"value":10},
                    {"source":0,"target":3,"value":40},
                    {"source":1,"target":2,"value":10},
                    {"source":3,"target":4,"value":25},
                    {"source":3,"target":5,"value":10},
                    {"source":3,"target":6,"value":5},
                    {"source":4,"target":6,"value":5},
                    {"source":4,"target":5,"value":15}
                ]
            }
             */

            var investment = EntityRepository.Entities.Find(ID);
            var nodes = new List<object> {new { name = investment.Name, value = 1 } };
            var links = new List<object>();
            var index = 1;
            foreach (var factor in investment.Factors)
            {
                nodes.Add(new { name = factor.Name, value = factor.Investments.Count });
                links.Add(new { source = 0, target=index, value = factor.Investments.Count });
                index++;
            }

            

            return Json( new { nodes = nodes, links = links }, JsonRequestBehavior.AllowGet);
        }

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
        private void AddCustomCreateAndCustomCreateRedirect(string checkItemsViewTitle, string createActionControllerName, string createActionName, string redirectToControllerName, string redirectToAction, object routeValues = null)
        {
            ViewBag.Title = checkItemsViewTitle;
            ViewBag.CustomActionUrl = Url.Action(createActionName, createActionControllerName, null, null);
            ViewBag.CustomActionName = "Create new " + createActionControllerName.ToLower();


            // This will force any Create actions to go to the following controller/action instead.
            OverrideCreateActionRedirect(redirectToControllerName, redirectToAction, routeValues);
        }

        /// <summary>
        /// "Create" actions usually redirect to the "Details" page unless we say otherwise here
        /// </summary>
        /// <param name="returnControllerName">controller to redirect to</param>
        /// <param name="returnAction">action in controller to redirect to</param>
        private void OverrideCreateActionRedirect(string returnControllerName, string returnAction, object routeValues = null)
        {
            TempData["ReturnAction"] = returnAction;
            TempData["ReturnController"] = returnControllerName;
            TempData["ReturnRouteValues"] = routeValues;
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
                  Checked = false,
                  Fields = new List<CustomField<string, string>> {
                      new CustomField<string, string> { Name = nameof(o.Type), Value = o.Type },
                      new CustomField<string, string> { Name = nameof(o.ID), Value = o.ID.ToString() },
                  }
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

        public ActionResult DissassociateRisk(int riskID, int investmentID)
        {
            var risk = EntityRepository.GetEntityByType<InvestmentRisk>().Find(riskID);
            var investment = EntityRepository.Entities.Find(investmentID);
            investment.Risks.Remove(risk);
            risk.Investments.Remove(investment);
            EntityRepository.SaveChanges();

            return RedirectToAction("Details", investment);
        }

        public ActionResult DissassociateFactor(int factorID, int investmentID)
        {
            var factor = EntityRepository.GetEntityByType<InvestmentInfluenceFactor>().Find(factorID);
            var investment = EntityRepository.Entities.Find(investmentID);
            investment.Factors.Remove(factor);
            factor.Investments.Remove(investment);
            EntityRepository.SaveChanges();

            return RedirectToAction("Details", investment);
        }

        public ActionResult DissassociateGroup(int groupID, int investmentID)
        {
            var group = EntityRepository.GetEntityByType<InvestmentGroup>().Find(groupID);
            var investment = EntityRepository.Entities.Find(investmentID);
            investment.Groups.Remove(group);
            group.Investments.Remove(investment);
            EntityRepository.SaveChanges();

            return RedirectToAction("Details", investment);
        }

        public ActionResult DissassociateRegion(int regionID, int investmentID)
        {
            var region = EntityRepository.GetEntityByType<Models.Region>().Find(regionID);
            var investment = EntityRepository.Entities.Find(investmentID);
            investment.Regions.Remove(region);
            region.Investments.Remove(investment);
            EntityRepository.SaveChanges();

            return RedirectToAction("Details", investment);
        }

        public ActionResult AssociateRisk(int id)
        {
            var investment = EntityRepository.Entities.Find(id);
            var model = new ParentChildEntity<CheckModel, Investment>
            {
                Parent = investment,
                Children = EntityRepository.GetEntityByType<InvestmentRisk>().Select(risk => new CheckModel
                {
                    ID = risk.ID, Name = risk.Name, Description = risk.Description, Checked = false
                }).ToList()
            };
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Risks", createActionControllerName: "Risk", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "AssociateRisk", routeValues: new { Id = id});
            return View("SelectItemsWithParent", model);
        }

        [HttpPost]
        [ClearCustomRedirects]
        public ActionResult AssociateRisk(int id, List<CheckModel> Children)
        {
            var investment = EntityRepository.Entities.Find(id);
            var riskIDs = Children.Where(o => o.Checked).Select(o => o.ID);
            foreach(var ID in riskIDs)
            {
                var risk = EntityRepository.GetEntityByType<InvestmentRisk>().Find(ID);
                if (!risk.Investments.Contains(investment)) {
                    risk.Investments.Add(investment);
                }
                if (!investment.Risks.Contains(risk)) {
                    investment.Risks.Add(risk);
                }
            }
            EntityRepository.SaveChanges();


            return RedirectToAction("Details", investment);
        }

        
        public ActionResult AssociateFactor(int id)
        {
            var investment = EntityRepository.Entities.Find(id);
            var model = new ParentChildEntity<CheckModel, Investment>
            {
                Parent = investment,
                Children = EntityRepository.GetEntityByType<InvestmentInfluenceFactor>().Select(risk => new CheckModel
                {
                    ID = risk.ID,
                    Name = risk.Name,
                    Description = risk.Description,
                    Checked = false
                }).ToList()
            };
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Factors", createActionControllerName: "Factor", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "AssociateFactor", routeValues: new { Id = id });
            return View("SelectItemsWithParent", model);
        }

        [HttpPost]
        [ClearCustomRedirects]
        public ActionResult AssociateFactor(int id, List<CheckModel> Children)
        {
            var investment = EntityRepository.Entities.Find(id);
            var factorIDs = Children.Where(o => o.Checked).Select(o => o.ID);
            foreach (var ID in factorIDs)
            {
                var factor = EntityRepository.GetEntityByType<InvestmentInfluenceFactor>().Find(ID);
                if (!factor.Investments.Contains(investment))
                {
                    factor.Investments.Add(investment);
                }
                if (!investment.Factors.Contains(factor))
                {
                    investment.Factors.Add(factor);
                }
            }
            EntityRepository.SaveChanges();


            return RedirectToAction("Details", investment);
        }
        
        public ActionResult AssociateGroup(int id)
        {
            var investment = EntityRepository.Entities.Find(id);
            var model = new ParentChildEntity<CheckModel, Investment>
            {
                Parent = investment,
                Children = EntityRepository.GetEntityByType<InvestmentGroup>().Select(group => new CheckModel
                {
                    ID = group.ID,
                    Name = group.Name,
                    Description = group.Description,
                    Checked = false,                    
                    
                }).ToList()
            };
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Groups", createActionControllerName: "Group", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "AssociateGroup", routeValues: new { Id = id });
            return View("SelectItemsWithParent", model);
        }

        [HttpPost]
        [ClearCustomRedirects]
        public ActionResult AssociateGroup(int id, List<CheckModel> Children)
        {
            var investment = EntityRepository.Entities.Find(id);
            var groupIDs = Children.Where(o => o.Checked).Select(o => o.ID);
            foreach (var ID in groupIDs)
            {
                var group = EntityRepository.GetEntityByType<InvestmentGroup>().Find(ID);
                if (!group.Investments.Contains(investment))
                {
                    group.Investments.Add(investment);
                }
                if (!investment.Groups.Contains(group))
                {
                    investment.Groups.Add(group);
                }
            }
            EntityRepository.SaveChanges();


            return RedirectToAction("Details", investment);
        }
        //
        public ActionResult AssociateRegion(int id)
        {
            var investment = EntityRepository.Entities.Find(id);
            var model = new ParentChildEntity<CheckModel, Investment>
            {
                Parent = investment,
                Children = EntityRepository.GetEntityByType<Region>().Select(risk => new CheckModel
                {
                    ID = risk.ID,
                    Name = risk.Name,
                    Description = risk.Description,
                    Checked = false
                }).ToList()
            };
            AddCustomCreateAndCustomCreateRedirect(checkItemsViewTitle: "Regions", createActionControllerName: "Region", createActionName: "Create", redirectToControllerName: "Investment", redirectToAction: "AssociateRegion", routeValues: new { Id = id });
            return View("SelectItemsWithParent", model);
        }

        [HttpPost]
        [ClearCustomRedirects]
        [GlobalLoggingAttribute]
        public ActionResult AssociateRegion(int id, List<CheckModel> Children)
        {
            var investment = EntityRepository.Entities.Find(id);
            var regionIDs = Children.Where(o => o.Checked).Select(o => o.ID);
            foreach (var ID in regionIDs)
            {
                var region = EntityRepository.GetEntityByType<Region>().Find(ID);
                if (!region.Investments.Contains(investment))
                {
                    region.Investments.Add(investment);
                }
                if (!investment.Regions.Contains(region))
                {
                    investment.Regions.Add(region);
                }
            }
            EntityRepository.SaveChanges();


            return RedirectToAction("Details", investment);
        }

        [GlobalLoggingAttribute]
        public ActionResult ShowGraph()
        {
            Logger.Debug("ShowGraph");
            return View();
        }
    }
}