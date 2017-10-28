using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models
{
    public class InvestmentInfluenceFactor : IDbInvestmentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }
        public String Influence { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}