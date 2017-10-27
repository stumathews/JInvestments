using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WinInvestmentTracker.Common;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models
{
    public class InvestmentRisk : IDbInvestmentEntity
    {
        [Key]
        public int ID { get; set; }
        public String Description { get; set; }
        public RiskType Type { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}