using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using WinInvestmentTracker.Models.DAL;
using WinInvestmentTracker.Models.DAL.Interfaces;
using WinInvestmentTracker.Common;
using log4net;
using UnityLog4NetExtension.Log4Net;

namespace WinInvestmentTracker
{
    static public class UnityUtilities
    {        
        public static void  RegisterTypes(UnityContainer container)
        {            
            container.AddNewExtension<Log4NetExtension>();
            container.RegisterType(typeof(IEntityApplicationDbContext<>), typeof(EntityApplicationDbContext<>));            
            container.RegisterType(typeof(IMyLogger), typeof(MyLogger));
        }

    }
}