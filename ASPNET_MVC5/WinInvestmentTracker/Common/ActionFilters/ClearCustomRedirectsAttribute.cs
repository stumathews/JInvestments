using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WinInvestmentTracker.Common
{
    public class ClearCustomRedirectsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.TempData.Remove("ReturnAction");
            filterContext.Controller.TempData.Remove("ReturnController");
            filterContext.Controller.TempData.Remove("ReturnRouteValues");
            base.OnActionExecuted(filterContext);
        }
    }
}