﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.Models.DAL
{
    /// <summary>
    /// This class is setup in the web.config to create new data in the database at startup.
    /// Its mentioned in the web.config
    /// </summary>
    public class DatabaseTestDataInitializer : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
    {
        /*
         * This method(seed) basically creates and adds our entities to our derived DbContext object,
         * which has a list(DbSet) for each of the entities we want to persist.
         * We basically create those entities here by hand and add them to that list in the DbContext.
         * We then ask the DBContext to SaveChanges() which persists what we've setup to be added to those lists(managed by the DbContext)
         */
        const int MAX = 10;        
        protected override void Seed(ApplicationDbContext db)
        {
            var MAX = 10;
            var factors = new List<InvestmentInfluenceFactor> {
                    new InvestmentInfluenceFactor {
                        Name = "Weather", Description = "The climate will affect the investment.",
                        Influence = "Sunny weather helps, rainy weather doesn't"},
                    new InvestmentInfluenceFactor {
                        Name = "Competiion", Description = "The competition dictates te supply and demand",
                        Influence = "The more cometition the less buiness you get if the competition or on par to you"},
            };
            String[] samples = new String[]
            {
                    "Transport",
                    "Travel/Tourism",
                    "Utilities",
                    "Telecommunications",
                    "Professional Services/Consulting",
                    "Pharmaceutical/Medical Product",
                    "Oil/Gas",
                    "Mining/Metals",
                    "Manufacturing",
                    "IT (Hardware/Software/Services)",
                    "Investment Banking",
                    "Food and Beverage",
                    "Consumer Goods",
                    "Agriculture"
            };
            foreach (String each in samples)
            {
                InvestmentInfluenceFactor f = new InvestmentInfluenceFactor { Name = each, Description = "description about " + each };
                f.Influence = "influenced by " + each;
                factors.Add(f);
            }
            factors.ForEach(f => f.Investments = new List<Investment>());
            factors.ForEach(f => db.Factors.Add(f));
            db.SaveChanges();

            var groups = new List<InvestmentGroup> {
                new InvestmentGroup{ Name = "Value Investments", Description = "high current p/e with potential to maintain.", Type = "Container" },
                new InvestmentGroup{ Name = "Growth Investments", Description = "Low p/e with potential to grow", Type = "Container" },
                new InvestmentGroup{ Name = "Momentum Investments", Description = "Fashionalble trends", Type = "Container" },
                new InvestmentGroup{ Name = "Hybrid Investments", Description = "Bit of everything", Type = "Container" },
                new InvestmentGroup{ Name = "Tactical", Description = "carefully considered group", Type = "Container" },
                new InvestmentGroup{ Name = "Strategic", Description = "Assets with a strategic goal associated with them", Type = "Container" },
                new InvestmentGroup{ Name = "Shares", Description = "Equity in company shares - fractional part owner", Type = "Container" },
                new InvestmentGroup{ Name = "Gold", Description = "ommodity which is valuable when markets are volatile", Type = "Container" },
                new InvestmentGroup{ Name = "Emerging markets", Description = "places like Japan, Turkey, Brazil, Taiwan etc.", Type = "Container" },
            };

            groups.ForEach(g => g.Investments = new List<Investment>());
            groups.ForEach(g => db.Groups.Add(g));

            db.SaveChanges();

            var regions = new List<Region> {
                new Region { Name = "UK ALL COMPANIES (Fund Sector)" },
                new Region { Name = "UK SMALLER COMPANIES (Fund Sector)"},
                new Region { Name = "JAPAN (Fund Sector)"},
                new Region { Name = "JAPANESE SMALLER COMPANIES (Fund Sector)"},
                new Region { Name = "ASIA PACIFIC EXCLUDING JAPAN (Fund Sector)"},
                new Region { Name = "CHINA / GREATER CHINA SECTOR (Fund Sector)"},
                new Region { Name = "NORTH AMERICA (Fund Sector)"},
                new Region { Name = "NORTH AMERICAN SMALLER COMPANIES (Fund Sector)"},
                new Region { Name = "EUROPE INCLUDING UK (Fund Sector)"},
                new Region { Name = "EUROPE EXCLUDING UK (Fund Sector)"},
                new Region { Name = "EUROPEAN SMALLER COMPANIES (Fund Sector)"},
                new Region { Name = "GLOBAL (Fund Sector)"},
                new Region { Name = "GLOBAL EMERGING MARKETS (Fund Sector)" }
            };

            regions.ForEach(r => r.Investments = new List<Investment>());
            regions.ForEach(r => db.Regions.Add(r));
            db.SaveChanges();

            var risks = new List<InvestmentRisk> {
                new InvestmentRisk { Name = "Director dismissal", Description = "Financial officer fired due to corruption", Type = Common.RiskType.Company },
                new InvestmentRisk { Name = "Competition", Description = "Competition from other companies", Type = Common.RiskType.Company },
                new InvestmentRisk { Name = "Fashion", Description = "Fashion/popularity of the comodity", Type = Common.RiskType.Company },
                new InvestmentRisk { Name = "Earnings report", Description = "Investor perception based on earnings", Type = Common.RiskType.Company },
            };

            risks.ForEach(r => r.Investments = new List<Investment>());
            risks.ForEach(r => db.Risks.Add(r));
            db.SaveChanges();

            var investments = new List<Investment>();
            for (int i = 0; i < MAX; i++)
            {
                var investment = new Investment
                {
                    Description = "Description",
                    Symbol = "symbol",
                    DesirabilityStatement = "default desirabliity statement#" + i,
                    InitialInvestment = i,
                    Name = "investment#" + i,
                    Value = i,
                    ValueProposition = "value proposition#" + i
                };

                investment.Factors = new List<InvestmentInfluenceFactor>();
                investment.Groups = new List<InvestmentGroup>();
                investment.Regions = new List<Region>();
                investment.Risks = new List<InvestmentRisk>();

                // now randomly assign some of the risks/factors/groups/regions to this investment
                // Get a randome number/sequence of items and then of those sequnece, choose a randome item each value in the sequence
                int gmax = gmax = new Random(DateTime.Now.Millisecond).Next(1, groups.Count);
                for (int g = 0; g < gmax; g++)
                {
                    var index = new Random(g).Next(1, groups.Count);
                    var group = groups[index];
                    group.Investments.Add(investment);
                    investment.Groups.Add(group);
                }

                int fmax = new Random(DateTime.Now.Millisecond).Next(1, factors.Count);
                for (int f = 0; f < fmax; f++)
                {
                    var index = new Random(f).Next(1, factors.Count);
                    var factor = factors[index];
                    factor.Investments.Add(investment);
                    investment.Factors.Add(factor);
                }

                int rmax = new Random(DateTime.Now.Millisecond).Next(1, risks.Count);
                for (int r = 0; r < rmax; r++)
                {
                    int index = new Random(r).Next(1, risks.Count);
                    var risk = risks[index];
                    risk.Investments.Add(investment);
                    investment.Risks.Add(risk);
                }

                int regionmax = new Random(DateTime.Now.Millisecond).Next(1, regions.Count);
                for (int r = 0; r < rmax; r++)
                {
                    int index = new Random(r).Next(1, regions.Count);
                    var region = regions[index];
                    region.Investments.Add(investment);
                    investment.Regions.Add(region);
                }
                investments.Add(investment);
            }

            investments.ForEach(inv => db.Investments.Add(inv));
            db.SaveChanges();

            base.Seed(db);
        }
    }
}