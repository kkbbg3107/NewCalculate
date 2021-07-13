using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.InterFace
{
    public interface IPostText
    {
        Task<Num> PostText(string text); // 回傳所有資料   
    }
}
