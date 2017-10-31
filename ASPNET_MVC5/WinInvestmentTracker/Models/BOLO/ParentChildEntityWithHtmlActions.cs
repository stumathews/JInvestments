using System.Collections.Generic;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.BOLO
{
    public class ParentChildEntityWithHtmlActions<TEntity1, TEntity2>
        where TEntity1 : class, IDbInvestmentEntity
        where TEntity2 : class, IDbInvestmentEntity
    {
        public IEnumerable<TEntity1> Children { get; set; }
        public TEntity2 Parent { get; set; }

        public IEnumerable<HtmlAction> HtmlActions { get; set; }
    }
}