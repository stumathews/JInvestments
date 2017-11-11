using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WinInvestmentTracker.Models.DAL;
using WinInvestmentTracker.Models.DAL.Interfaces;


namespace WinInvestmentTracker
{
    public static class UnityConfig
    {
        static private UnityContainer container = null;
        static private bool alreadyRegisteredComponents = false;
        static public UnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new UnityContainer();
                    if (!alreadyRegisteredComponents)
                    {
                        RegisterComponents();
                        alreadyRegisteredComponents = true;

                    }
                    return container;
                }
                return container;
            }
            set { }
        }

        public static T Resolve<T>()
        {
            return (T)Container.Resolve(typeof(T), null);
        }

        public static void RegisterComponents()
        {
            UnityUtilities.RegisterTypes(Container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}