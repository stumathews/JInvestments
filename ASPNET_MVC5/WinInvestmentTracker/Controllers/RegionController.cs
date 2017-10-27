using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    
    /// <summary>
    /// This automaticall maps /controller/method such as /region/xvz
    /// </summary>
    public class RegionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Region
        public ActionResult Index()
        {            
            return View(db.Regions.ToList());
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
                db.Regions.Add(region);
                db.SaveChanges();
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
            return View(db.Regions.SingleOrDefault( region => region.ID == id));
        }

        public ActionResult Api()
        {
            return Json(db.Regions.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int ID)
        {
            var candidate = db.Regions.Find(ID);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult Delete(Models.Region region)
        {
            var candidate = db.Regions.Find(region.ID);
            db.Regions.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {
            var candidate = db.Regions.Find(pk);
            WinInvestmentTracker.Common.ReflectionUtilities.SetPropertyValue(candidate, name, value);
            db.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}