using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public interface IFactory
    {
        Calculate PostAll(Calculate cal);
    }
}
