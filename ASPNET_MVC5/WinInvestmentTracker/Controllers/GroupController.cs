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
    }
}