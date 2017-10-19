using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WinInvestmentTracker.Common
{
    public class RunThisAfterActionCompleteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // do something
            base.OnActionExecuted(filterContext);
        }
    }
}