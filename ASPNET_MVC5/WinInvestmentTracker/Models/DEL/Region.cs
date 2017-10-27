using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.Models
{    
    public class Region : IInvestmentEntity
    {
        [Key]
        public int ID { get; set; }        
        [Display(Name = "Description of region")]
        public String Description { get; set; }
        [Required]
        [Display(Name="Region Name")]
        public String Name { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}