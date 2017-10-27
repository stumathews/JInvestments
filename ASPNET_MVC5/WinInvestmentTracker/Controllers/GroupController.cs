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
    public class GroupController : EntityManagedController<InvestmentGroup>
    {
        public ActionResult Index()
        {
            return View(EntityRepository.Entities.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvestmentGroup group)
        {
            try
            {
                EntityRepository.Entities.Add(group);
                EntityRepository.SaveChanges();
                return RedirectToAction("Details", group);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(EntityRepository.Entities.SingleOrDefault(group => group.ID == id));
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
        public ActionResult Delete(InvestmentGroup group)
        {
            var candidate = EntityRepository.Entities.Find(group.ID);
            EntityRepository.Entities.Remove(candidate);
            EntityRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}