﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    public class RiskController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {            
            return View(db.Risks.ToList());
        }

        // MVC 5 allows this as well as routesconfig class
        [Route("risk/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvestmentRisk risk)
        {
            try
            {
                db.Risks.Add(risk);
                db.SaveChanges();
                return RedirectToAction("Details", risk);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(db.Risks.SingleOrDefault(risk => risk.ID == id));
        }
    }
}