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
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Common
{
    /// <summary>
    /// A controller that has access the the strongly typed entity type specified through the EntityRepository memeber.
    /// Also contains the common controller Actions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityManagedController<T> : Controller where T : class, IDbInvestmentEntity
    {
        /// <summary>
        /// Access to te underlying store of entities
        /// </summary>
        [Dependency]
        protected IEntityApplicationDbContext<T> EntityRepository { get; set; }

        /// <summary>
        /// Primarily used to update entities using x-editable post backs
        /// </summary>
        /// <param name="name">name of changed entity property</param>
        /// <param name="value">value of the property</param>
        /// <param name="pk">the primary key of the entity</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {
            var candidate = EntityRepository.Entities.Find(pk);
            ReflectionUtilities.SetPropertyValue(candidate, name, value);
            EntityRepository.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns the Index view for this controller
        /// </summary>
        /// <returns>Index view</returns>
        public virtual ActionResult Index()
        {
            return View(EntityRepository.Entities.ToList());
        }

        /// <summary>
        /// Returns a parial view of the iddex view wihtout any layout scaffoldfing
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult IndexViewRaw()
        {
            // No layout stuff is wth view - maybe to embedded into another view
            // no head footer and css and javascript
            return PartialView("Index", EntityRepository.Entities.ToList());
        }

        /// <summary>
        /// Show create view for this entity
        /// </summary>
        /// <returns>Create view</returns>
        public virtual ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>view details of the entity</returns>
        [HttpPost]
        public virtual ActionResult Create(T entity)
        {
            try
            {
                EntityRepository.Entities.Add(entity);
                EntityRepository.SaveChanges();
                
                // We'll support a custom redirect if we've got one
                var returnAction = (string)TempData["ReturnAction"];
                var returnController = (string)TempData["ReturnController"];
                if (returnAction != null && returnController != null)
                {
                    return RedirectToAction(returnAction, returnController, null);
                }
                return RedirectToAction("Details", entity);
            }
            catch
            {
                return View(entity);
            }
        }

        /// <summary>
        /// Show Details page for the entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View of the details page for this entity</returns>
        public virtual ActionResult Details(int id)
        {
            return View(EntityRepository.Entities.Single(entity => entity.ID == id));
        }

        public virtual ActionResult Api()
        {
            return Json(EntityRepository.Entities.ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Shows the delete view for this entity
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>View of the delete view for this entity</returns>
        public virtual ActionResult Delete(int ID)
        {
            var candidate = EntityRepository.Entities.Find(ID);
            return View(candidate);
        }

        /// <summary>
        /// Deletes this entity
        /// </summary>
        /// <param name="entity">The entity to be deleted</param>
        /// <returns>View showing a list of all the entities</returns>
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