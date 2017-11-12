using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WinInvestmentTracker.Common.ActionFilters.WebApi
{
    public class GlobalLoggingWebApiAttribute : ActionFilterAttribute
    {        
        private IMyLogger Logger
        {
            get
            {
                return (IMyLogger)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IMyLogger));                                
            }
        }


        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Logger.Debug(string.Format("{0} WebApi Response Code: {1}", actionExecutedContext.Response, actionExecutedContext.Response.StatusCode.ToString()));
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            
            Logger.Debug(string.Format("WebApi Request {0} {1}", actionContext.Request.Method.ToString(), actionContext.Request.RequestUri.ToString()));
            return base.OnActionExecutingAsync(actionContext, cancellationToken);            
        }
    }
}