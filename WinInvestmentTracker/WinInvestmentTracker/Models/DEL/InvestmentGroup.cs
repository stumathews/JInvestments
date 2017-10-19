using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.Models
{
    public class InvestmentGroup
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
        public ICollection<InvestmentGroup> Groups { get; set; }
        public ICollection<Investment> Investments { get; set; }
        // Parent public virtual InvestmentGroup InvestmentGroup { get; set; }
        
    }
}