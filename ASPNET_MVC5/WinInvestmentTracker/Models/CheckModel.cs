using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models
{
    public class CheckModel : IDbInvestmentEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public string Description { get; set; }
    }
}