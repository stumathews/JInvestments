using System.Collections.Generic;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.BOLO
{
    public class ParentChildEntity<TEntity1, TEntity2>
        where TEntity1 : class, IDbInvestmentEntity
        where TEntity2 : class, IDbInvestmentEntity
    {
        public IEnumerable<TEntity1> Children { get; set; }
        public TEntity2 Parent { get; set; }
    }
}