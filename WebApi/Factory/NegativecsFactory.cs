using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Factory
{
    public class NegativeFactory : IButton
    {
        private readonly Calculate _cal;
        public NegativeFactory(Calculate cal)
        {
            _cal = cal;
        }

        public Calculate PostAll(Calculate cal)
        {
            cal.TextboxFirst = "(" + cal.TextboxFirst.Insert(0, "-") + ")";

            return cal;
        }

        public IFactory UseButton(Calculate cal)
        {
            var negative = new NegativeFactory(cal);

            cal.TextboxFirst = "(" + cal.TextboxFirst.Insert(0, "-") + ")";

            return negative;        
        }
    }
}
