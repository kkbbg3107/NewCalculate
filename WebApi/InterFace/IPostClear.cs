using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.InterFace
{
    public interface IPostClear
    {
        Task<Num> PostBlank(string text); // 回傳string.empty
    }
}
