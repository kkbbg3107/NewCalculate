using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApi.Factory
{
    public class ClearFactory : IButton
    {

        private readonly Calculate _cal;
        public ClearFactory(Calculate cal)
        {
            _cal = cal;
        }

        public IFactory UseButton(Calculate cal)
        {
            ClearFactory clear = new ClearFactory(cal);
            
            cal.Label = string.Empty;
            cal.TextboxFirst = string.Empty;

            return clear;
        }
    }
}
