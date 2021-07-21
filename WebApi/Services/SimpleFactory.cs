using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class SimpleFactory
    {
        private IFactory Get(string butonnType)
        {
            return null;
        }

        //public Calculate PostAll(Calculate cal)
        //{
        //    if (cal.Button == "api")
        //    {
        //        Api api = new Api();
        //        api.PostAll(cal);
        //        return cal;
        //    }
        //    if (cal.Button == "C")
        //    {
        //        Clear clear = new Clear();
        //        clear.PostAll(cal);
        //        return cal;
        //    }
        //    if (cal.Button == "√")
        //    {
        //        SquareRoot squareRoot = new SquareRoot();
        //        squareRoot.PostAll(cal);
        //        return cal;
        //    }
        //    if (cal.Button == "+/-")
        //    {
        //        Negative negative = new Negative();
        //        negative.PostAll(cal);
        //        return cal;
        //    }
        //    else
        //    {
        //        Num num = new Num();
        //        num.PostAll(cal);
        //        return cal;
        //    }
        //}
    }
}
