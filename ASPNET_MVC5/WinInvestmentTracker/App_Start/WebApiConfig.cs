using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using WinInvestmentTracker.Models;

namespace WinInvestmentTracker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            UnityUtilities.RegisterTypes(container);

            config.DependencyResolver = new UnityDependencyResolver(container);


            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Investment>("Investments");
            builder.EntitySet<InvestmentInfluenceFactor>("Factors"); 
            builder.EntitySet<InvestmentGroup>("Groups"); 
            builder.EntitySet<Region>("Regions"); 
            builder.EntitySet<InvestmentRisk>("Risks");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
