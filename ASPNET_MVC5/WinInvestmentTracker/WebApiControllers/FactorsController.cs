using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Common.ActionFilters.WebApi;
using WinInvestmentTracker.Models;

namespace WinInvestmentTracker.Controllers
{
    [GlobalLoggingWebApi]
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
