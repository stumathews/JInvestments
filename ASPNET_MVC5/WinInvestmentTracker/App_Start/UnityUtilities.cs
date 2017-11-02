using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using WinInvestmentTracker.Models.DAL;
using WinInvestmentTracker.Models.DAL.Interfaces;

namespace WinInvestmentTracker
{
    static internal class UnityUtilities
    {
        
        public static void  RegisterTypes(UnityContainer container)
        {
            container.RegisterType(typeof(IEntityApplicationDbContext<>), typeof(EntityApplicationDbContext<>));
        }
    }
}