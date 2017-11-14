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
using Microsoft.Practices.Unity;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DAL;
using WinInvestmentTracker.Models.DAL.Interfaces;
using WinInvestmentTracker.Common.ActionFilters.WebApi;

namespace WinInvestmentTracker.Controllers
{
    [GlobalLoggingWebApi]
    public class InvestmentsController : EntityManagedODataController<Investment>
    {
        
        // GET: odata/Investments
        [EnableQuery]
        public IQueryable<Investment> GetInvestments()
        {
            return EntityRepository.Entities;
        }

        // GET: odata/Investments(5)
        [EnableQuery]
        public SingleResult<Investment> GetInvestment([FromODataUri] int key)
        {
            return SingleResult.Create(EntityRepository.Entities.Where(investment => investment.ID == key));
        }

        // PUT: odata/Investments(5)
        

        // GET: odata/Investments(5)/Factors
        [EnableQuery]
        public IQueryable<InvestmentInfluenceFactor> GetFactors([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Factors);
        }

        // GET: odata/Investments(5)/Groups
        [EnableQuery]
        public IQueryable<InvestmentGroup> GetGroups([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Groups);
        }

        // GET: odata/Investments(5)/Regions
        [EnableQuery]
        public IQueryable<Region> GetRegions([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Regions);
        }

        // GET: odata/Investments(5)/Risks
        [EnableQuery]
        public IQueryable<InvestmentRisk> GetRisks([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Risks);
        }
    }
}
