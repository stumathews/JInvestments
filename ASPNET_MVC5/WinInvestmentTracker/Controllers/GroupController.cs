using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    public class GroupController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {         
            return View(db.Groups.ToList());
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
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Details", group);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(db.Groups.SingleOrDefault(group => group.ID == id));
        }

        public ActionResult Api()
        {
            return Json(db.Groups.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int ID)
        {
            var candidate = db.Groups.Find(ID);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult Delete(InvestmentGroup group)
        {
            var candidate = db.Groups.Find(group.ID);
            db.Groups.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {
            var candidate = db.Groups.Find(pk);
            WinInvestmentTracker.Common.ReflectionUtilities.SetPropertyValue(candidate, name, value);
            db.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

    }
}