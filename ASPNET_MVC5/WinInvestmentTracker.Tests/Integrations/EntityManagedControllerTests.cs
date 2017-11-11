using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinInvestmentTracker.Controllers;
using WinInvestmentTracker.Models.DEL.Interfaces;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models.DAL.Interfaces;

using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DEL;

namespace WinInvestmentTracker.Tests.Controllers
{
    [TestClass]
    public class EntityManagedControllerTests
    {        
      
        [TestMethod]
        public void TestIndexWorks()
        {
            
        }

        [TestMethod]
        public void TestCreateWorks()
        {
            var dbContext = UnityConfig.Resolve<IEntityApplicationDbContext<InvestmentInfluenceFactor>>();
            var controller = (EntityManagedController<InvestmentInfluenceFactor>)new FactorController();
            controller.AddEntityApplicationDbContext(dbContext);
            // Create a new entity and verify that it works.
            var entity = new InvestmentInfluenceFactor
            {
                Description = "Test Description",                
                Name = "Test Investment Name",
               Influence = "Test Influence"
            };
            controller.Create(entity);
           

        }
        [TestMethod]
        public void TestCreateNote()
        {
            InvestmentInfluenceFactor factor = new InvestmentInfluenceFactor
            {
                Name = "My new super influence factor",
                Description = "Something great and awe inspiring",
                Influence = "Something equally great and awe inspiring"
            };

            Investment inv = new Investment {
                Name = "Test Investment Name",
                Description = "Test Description",
            };

            InvestmentNote aInfluenceNote = new InvestmentNote
            {
                Name = "",
                Description = "This is the contents of the note",
                @Investment = inv
            };

            var dbContext = UnityConfig.Resolve<IEntityApplicationDbContext<InvestmentNote>>();
            dbContext.Entities.Add(aInfluenceNote);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void TestDeleteWorks() { }

        [TestMethod]
        public void TestDetailsWorks() { }

        [TestMethod]
        public void TestIndexViewRawWorks() { }

        [TestMethod]
        public void TestUpdateWorks() { }

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
