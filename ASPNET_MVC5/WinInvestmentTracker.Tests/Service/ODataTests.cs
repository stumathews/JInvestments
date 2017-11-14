using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WinInvestmentTracker.Tests.Service
{
    [TestClass]
    public class ODataTests
    {
        private static OdataClient _client = null;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _client = new OdataClient(new Uri("http://localhost:52704/odata"));
        }

        [TestMethod]
        public void AddNewFactor()
        {
            
            var factors = _client.Factors;
            var @new = new InvestmentInfluenceFactor
            {
                Description = "Odata Test Description",
                Name = "OData Test Name",
                Influence = "Odata Test Influence"
            };

            _client.AddToFactors(@new);
            
            _client.SaveChanges();
        }

        [TestMethod]
        public void RandomlyAssignExisingInvestnents()
        {
            var investments = _client.Investments;
            var rand = new Random();
            foreach (var investment in investments)
            {
                investment.Value = rand.Next(0, 100);
                _client.UpdateObject(investment);
            }
            _client.SaveChanges();

        }
    }
}
