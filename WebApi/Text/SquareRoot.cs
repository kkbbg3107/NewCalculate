using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Text
{
    public class SquareRoot : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            if (double.TryParse(cal.TextboxFirst, out var number))
            {
                cal.TextboxFirst = Math.Sqrt(number).ToString();
            }

            return cal;
        }
    }
}
