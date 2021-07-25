using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Factory
{
    public class SquareRootFactory : IButton
    {

        private readonly Calculate _cal;
        public SquareRootFactory(Calculate cal)
        {
            _cal = cal;
        }
        //public Calculate PostAll(Calculate cal)
        //{
        //    if (double.TryParse(cal.TextboxFirst, out var number))
        //    {
        //        cal.TextboxFirst = Math.Sqrt(number).ToString();
        //    }

        //    return cal;
        //}

        public IFactory UseButton(Calculate cal)
        {
            var squareRoot = new SquareRootFactory(cal);
            
            if (double.TryParse(cal.TextboxFirst, out var number))
            {
                cal.TextboxFirst = Math.Sqrt(number).ToString();
            }

            return squareRoot;
        }
    }
}
