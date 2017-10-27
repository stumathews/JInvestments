using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;
using WinInvestmentTracker.Models.DAL.Interfaces;

namespace WinInvestmentTracker.Common
{
    /// <summary>
    /// A controller that has access the the strongly typed entity type specified through the EntityRepository memeber.
    /// Also contains the common controller Actions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityManagedController<T> : Controller where T : class, IInvestmentEntity
    {
        [Dependency]
        protected IEntityApplicationDbContext<T> EntityRepository { get; set; }

        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {
            var candidate = EntityRepository.Entities.Find(pk);
            ReflectionUtilities.SetPropertyValue(candidate, name, value);
            EntityRepository.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        public virtual ActionResult Index()
        {
            return View(EntityRepository.Entities.ToList());
        }

        public virtual ActionResult IndexViewRaw()
        {
            // No layout stuff is wth view - maybe to embedded into another view
            // no head footer and css and javascript
            return PartialView("Index", EntityRepository.Entities.ToList());
        }

        // GET(default): Request a create action to present them a form
        public virtual ActionResult Create()
        {
            return View();
        }

        // Create a new Investment
        [HttpPost]
        public virtual ActionResult Create(T entity)
        {
            try
            {
                EntityRepository.Entities.Add(entity);
                EntityRepository.SaveChanges();
                return RedirectToAction("Details", entity);
            }
            catch
            {
                return View(entity);
            }
        }

        public virtual ActionResult Details(int id)
        {
            return View(EntityRepository.Entities.Single(entity => entity.ID == id));
        }

        public virtual ActionResult Api()
        {
            return Json(EntityRepository.Entities.ToList(), JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Delete(int ID)
        {
            var candidate = EntityRepository.Entities.Find(ID);
            return View(candidate);
        }

        [HttpPost]
        public virtual ActionResult Delete(T entity)
        {
            var candidate = EntityRepository.Entities.Find(entity.ID);
            EntityRepository.Entities.Remove(candidate);
            EntityRepository.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}