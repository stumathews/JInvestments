using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.Models.DAL
{
    /// <summary>
    /// This will manage our interaction with the database
    /// </summary>
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
            // The name of the connection string in web.config is passed into this constructor
        }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentGroup> Groups { get; set; }
        public DbSet<InvestmentInfluenceFactor> Factors { get; set; }
        public DbSet<InvestmentRisk> Risks { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}