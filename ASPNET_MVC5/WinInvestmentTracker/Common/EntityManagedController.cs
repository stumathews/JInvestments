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

namespace WinInvestmentTracker.Common
{
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