using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    
    /// <summary>
    /// This automaticall maps /controller/method such as /region/xvz
    /// </summary>
    public class RegionController : EntityManagedController<Models.Region>
    {
        // GET: Region
        public ActionResult Index()
        {            
            return View(EntityRepository.Entities.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Region region)
        {
            try
            {
                EntityRepository.Entities.Add(region);
                EntityRepository.SaveChanges();
                return RedirectToAction("Details", region);
            }
            catch
            {
                // was a problem, go back to yourself!
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(EntityRepository.Entities.SingleOrDefault( region => region.ID == id));
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
        public ActionResult Delete(Models.Region region)
        {
            var candidate = EntityRepository.Entities.Find(region.ID);
            EntityRepository.Entities.Remove(candidate);
            EntityRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}