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
        public ActionResult Create(Models.Region region)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                // was a problem, go back to yourself!
                return View();
            }
        }
    }
}