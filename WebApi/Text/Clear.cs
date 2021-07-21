using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Text
{
    public class Clear : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            cal.Label = string.Empty;
            cal.TextboxFirst = string.Empty;

            return cal;
        }
    }
}
