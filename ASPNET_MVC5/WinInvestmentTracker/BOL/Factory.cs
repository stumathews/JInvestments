using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.BOL
{
    public interface IProduct<T>
    {
        void EmptyContents();
        void UpdateLabel();
        void UpdateColour();
    }
    public class Bottle : IProduct<Bottle>
    {
        public void EmptyContents()
        {
            throw new NotImplementedException();
        }

        public void UpdateColour()
        {
            throw new NotImplementedException();
        }

        public void UpdateLabel()
        {
            throw new NotImplementedException();
        }
    }
    public class Factory
    {
        public static IProduct<T> Create<T>()
        {
            var product = new Bottle();
            // pass in object to be decorated
            var proxy = new AOPProxy<Bottle>(product);
            proxy.BeforeExecute += (s, o) => { Console.WriteLine("Before Execute!"); };
            proxy.AfterExecute += (s, o) => { Console.WriteLine("After Execute!"); };
            proxy.ErrorExecute += (s, o) => { Console.WriteLine("Error Execute!"); };
            proxy.Filter = m => !m.Name.StartsWith("Get");
            //  Return the decorated object
            return proxy.GetTransparentProxy() as IProduct<T>;
        }

        
    }
}