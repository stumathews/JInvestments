using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.Models
{
    public class InvestmentInfluenceFactor : IInvestmentEntity
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Influence { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}