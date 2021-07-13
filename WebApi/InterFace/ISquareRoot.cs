using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.InterFace
{
    public interface ISquareRoot
    {
        Task<Num> PostSquare(string text);
    }
}
