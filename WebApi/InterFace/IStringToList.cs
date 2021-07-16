using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.InterFace
{
    /// <summary>
    /// 算式字串轉換集合
    /// </summary>
    public interface IStringToList
    {
        /// <summary>
        /// 取得算式集合
        /// </summary>
        /// <param name="infix">算式字串</param>
        /// <returns>算式集合</returns>
        List<string> ToListService(string infix);
    }
}
