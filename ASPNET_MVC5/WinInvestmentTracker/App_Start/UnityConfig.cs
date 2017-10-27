using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WinInvestmentTracker.Models.DAL;

namespace WinInvestmentTracker
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IApplicationDbContext<>), typeof(EntityApplicationDbContext<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}