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
using WinInvestmentTracker.Common.ActionFilters.WebApi;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker.Controllers
{
    [GlobalLoggingWebApi]
    public class GroupsController : EntityManagedODataController<InvestmentGroup>
    {

        // GET: odata/InvestmentGroups
        [EnableQuery]
        public IQueryable<InvestmentGroup> GetGroups()
        {
            return EntityRepository.Entities;
        }

        // GET: odata/InvestmentGroups(5)
        [EnableQuery]
        public SingleResult<InvestmentGroup> GetGroup([FromODataUri] int key)
        {
            return SingleResult.Create(EntityRepository.Entities.Where(investmentGroup => investmentGroup.ID == key));
        }
        
        // GET: odata/InvestmentGroups(5)/Groups
        [EnableQuery]
        public IQueryable<InvestmentGroup> GetGroups([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Groups);
        }

        // GET: odata/InvestmentGroups(5)/Investments
        [EnableQuery]
        public IQueryable<Investment> GetInvestments([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Investments);
        }
    }
}
