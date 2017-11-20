using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models
{
    public class InvestmentGroup : IDbInvestmentEntity, IDbInvestmentEntityHasInvestments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
        public ICollection<InvestmentGroup> Groups { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
        // Parent public virtual InvestmentGroup InvestmentGroup { get; set; }
        
    }
}