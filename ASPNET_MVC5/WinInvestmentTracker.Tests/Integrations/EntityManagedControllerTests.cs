using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinInvestmentTracker.Controllers;
using WinInvestmentTracker.Models.DEL.Interfaces;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models.DAL.Interfaces;
using WinInvestmentTracker.Models;

namespace WinInvestmentTracker.Tests.Controllers
{
    [TestClass]
    public class EntityManagedControllerTests
    {        
        
        [TestMethod]
        public void TestEntityManagedControllerReturnsIndex()
        {            
            var dbContext = UnityConfig.Resolve<IEntityApplicationDbContext<Investment>>();
            var anyEntityManagedController = new InvestmentController();
            anyEntityManagedController.AddEntityApplicationDbContext(dbContext);
            var indexResult = anyEntityManagedController.Index();
        }

        [TestInitialize]
        public void AlwaysRunBeforeEachTest()
        {
        }

        [TestCleanup]
        public void AlwaysRunAfterEachTest()
        {

        }

        [ClassInitialize]
        public static void BeforeAllTests(TestContext context)
        {
        }

        [ClassCleanup]
        public static void AfterAllTests()
        {
            
        }
    }
}
