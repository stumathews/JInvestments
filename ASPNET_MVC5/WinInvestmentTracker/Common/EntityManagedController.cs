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
    /// Also contains the common Update() Action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityManagedController<T> : Controller where T : class
    {
        [Dependency]
        protected IApplicationDbContext<T> EntityRepository { get; set; }

        [HttpPost]
        public ActionResult Update(string name, string value, int pk)
        {
            var candidate = EntityRepository.Entities.Find(pk);
            ReflectionUtilities.SetPropertyValue(candidate, name, value);
            EntityRepository.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

    }
}