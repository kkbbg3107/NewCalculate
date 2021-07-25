using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using WebApi;
using WebApi.Factory;

namespace WebApi
{
    public class SimpleFactory : IFactory
    {
        //private IFactory Get(Calculate cal) // 回傳介面 確保都有使用到該有的成員
        //{
        //    var result =
        //    return null;
        //}
        private readonly IFactory _factory;
        public SimpleFactory(IFactory factory)
        {
            if (factory == null)
            {
                throw new AccessViolationException("factory 為空值");
            }

            this._factory = factory;
        }

        //public Calculate PostAll(Calculate cal)
        //{
        //    if (cal.Button == "api")
        //    {
        //        ApiFactory api = new ApiFactory();
        //        api.PostAll(cal);
        //        return cal;
        //    }
        //    if (cal.Button == "C")
        //    {
        //        ClearFactory clear = new ClearFactory();
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
        //        NumFactory num = new NumFactory();
        //        num.PostAll(cal);
        //        return cal;
        //    }
        //}

        public IButton UseButton(Calculate cal)
        {            

            if (cal.Button == "api")
            {
                _factory.UseButton(cal);
                return new ApiFactory(cal);
            }
            if (cal.Button == "C")
            {
                
                _factory.UseButton(cal);
                return new ClearFactory(cal);
            }
            if (cal.Button == "√")
            {
               
                _factory.UseButton(cal);
                return new SquareRootFactory(cal);
            }
            if (cal.Button == "+/-")
            {             
                _factory.UseButton(cal);
                return new NegativeFactory(cal);
            }
            else
            {
                _factory.UseButton(cal);
                return new NumFactory(cal);
            }
        }
    }
}
