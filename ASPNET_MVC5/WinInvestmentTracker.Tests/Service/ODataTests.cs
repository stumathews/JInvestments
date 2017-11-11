using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WinInvestmentTracker.Tests.Service
{
    [TestClass]
    public class ODataTests
    {
        [TestMethod]
        public void AddNewFactor()
        {
            OdataClient client = new OdataClient(new Uri("http://localhost:52704/odata"));
            var factors = client.Factors;
            var @new = new InvestmentInfluenceFactor
            {
                Description = "Odata Test Description",
                Name = "OData Test Name",
                Influence = "Odata Test Influence"
            };

            client.AddToFactors(@new);
            
            client.SaveChanges();
            
            
        }
    }
}
