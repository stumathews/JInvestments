using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WinInvestmentTracker.Common;
using System.Linq;
using System.Web.Http.Filters;

namespace WinInvestmentTracker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalLoggingAttribute());
        }
    }
}
