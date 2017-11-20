using System.Collections.Generic;
using WinInvestmentTracker.Models;

namespace WinInvestmentTracker.Models
{
    public  interface IDbInvestmentEntityHasInvestments
    {
        ICollection<Investment> Investments { get; set; }
    }
}