using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.InterFace
{
    public interface INegative
    {
        Task<Num> PostNegative(string text);
    }
}
