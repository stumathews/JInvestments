using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    
    public class RegionsController : EntityManagedODataController<Region>
    {

        // GET: odata/Regions
        [EnableQuery]
        public IQueryable<Region> GetRegions()
        {
            return EntityRepository.Entities;
        }

        // GET: odata/Regions(5)
        [EnableQuery]
        public SingleResult<Region> GetRegion([FromODataUri] int key)
        {
            return SingleResult.Create(EntityRepository.Entities.Where(region => region.ID == key));
        }
        
        // GET: odata/Regions(5)/Investments
        [EnableQuery]
        public IQueryable<Investment> GetInvestments([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Investments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                EntityRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegionExists(int key)
        {
            return EntityRepository.Entities.Count(e => e.ID == key) > 0;
        }
    }
}
