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
    [GlobalLogging]
    public class FactorsController : EntityManagedODataController<InvestmentInfluenceFactor>
    {
        
        // GET: odata/Factors
        [EnableQuery]
        public IQueryable<InvestmentInfluenceFactor> GetFactors()
        {
            return EntityRepository.Entities;
        }

        // GET: odata/Factors(5)
        [EnableQuery]
        public SingleResult<InvestmentInfluenceFactor> GetInvestmentInfluenceFactor([FromODataUri] int key)
        {
            return SingleResult.Create(EntityRepository.Entities.Where(investmentInfluenceFactor => investmentInfluenceFactor.ID == key));
        }

        // GET: odata/Factors(5)/Investments
        [EnableQuery]
        public IQueryable<Investment> GetInvestments([FromODataUri] int key)
        {
            return EntityRepository.Entities.Where(m => m.ID == key).SelectMany(m => m.Investments);
        }
        
    }
}
