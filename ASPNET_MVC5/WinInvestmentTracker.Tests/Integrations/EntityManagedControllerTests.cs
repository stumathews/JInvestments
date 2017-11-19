using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinInvestmentTracker.Controllers;
using WinInvestmentTracker.Models.DEL.Interfaces;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models.DAL.Interfaces;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using WinInvestmentTracker.Models;
using WinInvestmentTracker.Models.DEL;
using System.Data.Entity;
using Moq;
using WinInvestmentTracker.Models.DAL;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WinInvestmentTracker.Tests.Controllers
{
    public class AnyIDbInvestmentEntity : IDbInvestmentEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [TestClass]
    public class EntityManagedControllerTests 
    {
        EntityManagedController<IDbInvestmentEntity> controller = new EntityManagedController<IDbInvestmentEntity>();
        Mock<EntityApplicationDbContext<IDbInvestmentEntity>> dbContext = new Mock<EntityApplicationDbContext<IDbInvestmentEntity>>();
        Mock<DbSet<IDbInvestmentEntity>> entities = new Mock<DbSet<IDbInvestmentEntity>>();
        List<IDbInvestmentEntity> rawData;
        IQueryable<IDbInvestmentEntity> data;

        [TestMethod]
        public void CreatePost()
        {
            entities.Setup(m => m.Add(It.IsAny<IDbInvestmentEntity>())).Callback<IDbInvestmentEntity>((e) => { rawData.Add(e); });
            
            var newEntity = new AnyIDbInvestmentEntity { Name = "Test Name", Description = "Test Description" };

            var result = (RedirectToRouteResult) controller.Create(newEntity);
            Assert.AreEqual(result.RouteValues["action"], "Details");
            dbContext.Verify(v => v.Entities, Times.AtLeastOnce);
            dbContext.Verify(v => v.SaveChanges(), Times.AtLeastOnce);
            Assert.AreEqual(rawData.Count, 4);
            Assert.IsTrue(rawData.Contains(newEntity));
        }

        [TestMethod]
        public void Create2()
        {          
            var result = (ViewResult) controller.Create();
            
        }

        [TestMethod]
        public void Details()
        {
            var entity = data.First();
            entities.Setup(m => m.Find(It.IsAny<int>())).Returns(entity);
            var result = (ViewResult) controller.Details(entity.ID);
            Assert.AreEqual(result.View, null);
            Assert.AreEqual(result.Model, entity);            
        }

       
        
        [TestMethod]
        public void Delete()
        {
            var entity = data.First();
            entities.Setup(m => m.Find(It.IsAny<int>())).Returns(entity);
            var result = (ViewResult)controller.Delete(entity.ID);
            Assert.AreEqual(result.Model, entity);
        }

        [TestMethod]
        public void DeletePost()
        {
            var entity = data.First();
            entities.Setup(m => m.Remove(It.IsAny<IDbInvestmentEntity>())).Callback<IDbInvestmentEntity>((i) => 
            {
                rawData.Remove(i);
                Assert.AreEqual<int>(2, rawData.Count);
            });
            entities.Setup(m => m.Find(It.IsAny<int>())).Returns(entity);
            
            var result = (RedirectToRouteResult) controller.Delete(entity);
            
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
            dbContext.Verify(context => context.SaveChanges(), Times.Once);
            entities.Verify(db => db.Remove(It.IsAny<IDbInvestmentEntity>()), Times.Once);
        }
        

        [TestMethod]
        public void IndexViewRawWorks()
        {
           
            var result = (PartialViewResult) controller.IndexViewRaw();
            Assert.AreEqual(result.ViewName, "Index");
            Assert.AreEqual(result.Model.GetType(), typeof(List<IDbInvestmentEntity>));
            var resultModelIDs  = ((List<IDbInvestmentEntity>) result.Model).Select(o=>o.ID).ToList();
            var rawDataIds = rawData.Select(o => o.ID).ToList();
            Assert.IsTrue( resultModelIDs.All( a => rawDataIds.Contains(a)) );
        }

        [TestMethod]
        public void Index()
        {
            var result = (ViewResult)controller.Index();            
            Assert.AreEqual(result.Model.GetType(), typeof(List<IDbInvestmentEntity>));
            var resultModelIDs = ((List<IDbInvestmentEntity>)result.Model).Select(o => o.ID).ToList();
            var rawDataIds = rawData.Select(o => o.ID).ToList();
            Assert.IsTrue(resultModelIDs.All(a => rawDataIds.Contains(a)));
        }

        [TestMethod]
        public void Update()
        {
            var entity = data.First();
            entities.Setup(m => m.Find(It.IsAny<int>())).Returns(entity);
            var result = (HttpStatusCodeResult) controller.Update("Name", "Poo", entity.ID);

            dbContext.Verify(m => m.SaveChanges(), Times.AtLeastOnce);
            Assert.AreEqual(entity.Name, "Poo");
            Assert.AreEqual(result.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void Create3()
        {
            // We're mocking real concreate objects here not interfaces, and will set them up to return fake data soon.    
            var mockDbContext = new Mock<EntityApplicationDbContext<Investment>>();
            var mockDbSet = new Mock<DbSet<Investment>>();

            // Some fake data 
            var raw = new List<Investment>
            {
                new Investment { Name = "A", Description = "A Some description", DesirabilityStatement = "A some statemnt", InitialInvestment = 0, Symbol = "$", Value = 1, ValueProposition = "A some text", ID = 1},
                new Investment { Name = "B", Description = "B Some description", DesirabilityStatement = "B some statemnt", InitialInvestment = 0, Symbol = "£", Value = 1, ValueProposition = "B some text", ID = 2},
                new Investment { Name = "C", Description = "C Some description", DesirabilityStatement = "C some statemnt", InitialInvestment = 0, Symbol = "R", Value = 1, ValueProposition = "C some text", ID = 3},

            };

            var querablyData = raw.AsQueryable();

            // make EntityFramework compatible setup operations for the dbset to  work under mocked circumstances
            mockDbSet.As<IQueryable<Investment>>().Setup(m => m.Provider).Returns(querablyData.Provider);
            mockDbSet.As<IQueryable<Investment>>().Setup(m => m.Expression).Returns(querablyData.Expression);
            mockDbSet.As<IQueryable<Investment>>().Setup(m => m.ElementType).Returns(querablyData.ElementType);
            mockDbSet.As<IQueryable<Investment>>().Setup(m => m.GetEnumerator()).Returns(querablyData.GetEnumerator());

            // Lets controll the behavior of the mocked/in-memory objects:

            //to do what we want with the Entities property...
            mockDbContext.Setup(x => x.Entities).Returns(mockDbSet.Object);

            // When you call Add on the mock Sb Set add the parameter to the rawData - here we are simulating entirely what the mock object will do
            // Remember mock objects are not by defualt any knid of implemtnation - all aspects of the mocked object need to be defined, if you use
            // all aspects(properties, functions, properties  etc) otherwise just the aspects of the mocked object you will be executing need implemenations in memory(be setup())

            mockDbSet.Setup(m => m.Add(It.IsAny<Investment>())).Callback<Investment>((i) => { raw.Add(i); });

            // Ok, lets pass in that mocked object to the concrete EntityManangedController
            var controller = new EntityManagedController<Investment>();
            controller.AddEntityApplicationDbContext(mockDbContext.Object);

            var entity = new Investment
            {
                Description = "Test Description",
                Name = "Test Investment Name"
            };

            // now internally to controller.Create() the mocked object(EntityApplicationDbContext)'s Add() function will be called.
            // We had to then define that implememation of Add (see above0 with call back.
            var createResult = controller.Create(entity);
            Assert.AreEqual(4, mockDbContext.Object.Entities.Count());
            mockDbSet.Verify(m => m.Add(It.IsAny<Investment>()));
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [TestInitialize]
        public void RunBeforeEachTest()
        {
            // Set the test data 
            rawData = new List<IDbInvestmentEntity>
            {
                new AnyIDbInvestmentEntity { Name = "A", Description = "Some description", ID = 1 },
                new AnyIDbInvestmentEntity { Name = "B", Description = "Some description", ID = 2 },
                new AnyIDbInvestmentEntity { Name = "C", Description = "Some description", ID = 3 }

            };
            data = rawData.AsQueryable();

            entities.As<IQueryable<IDbInvestmentEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            entities.As<IQueryable<IDbInvestmentEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            entities.As<IQueryable<IDbInvestmentEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            entities.As<IQueryable<IDbInvestmentEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            
            dbContext.Setup(db => db.Entities).Returns(entities.Object);
            controller.AddEntityApplicationDbContext(dbContext.Object);

        }
        
        [TestCleanup]
        public void RunAfterEachTest()
        {
            // Reset the test data
            rawData = new List<IDbInvestmentEntity>
            {
                new AnyIDbInvestmentEntity { Name = "A", Description = "Some description", ID = 1 },
                new AnyIDbInvestmentEntity { Name = "B", Description = "Some description", ID = 2 },
                new AnyIDbInvestmentEntity { Name = "C", Description = "Some description", ID = 3 }

            };
        }

        [ClassInitialize]
        public static void BeforeAllTestsRun(TestContext context) { }

        [ClassCleanup]
        public static void AfterAllTestsRun() { }
    }
}
