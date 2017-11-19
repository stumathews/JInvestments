using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinInvestmentTracker.Controllers;
using WinInvestmentTracker.Tests.Controllers;

namespace WinInvestmentTracker.Tests.Integrations
{
    [TestClass]
    public class HomeControllerTests 
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index();
        }        
    }
}
