using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.BOLO
{
    public class EntityWithHtmlActions<TEntity1> 
        where TEntity1 : class, IDbInvestmentEntity
    {
        public IEnumerable<TEntity1> Entities { get; set; }
        public IEnumerable<HtmlAction> HtmlActions { get; set; }
    }
}