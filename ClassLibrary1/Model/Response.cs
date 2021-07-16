using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    /// <summary>
    /// 存取前中後序結果值
    /// </summary>
    public class Response
    {
        public string Text { get; set; }

        // 後序表達式
        public string Postfix { get; set; }

        // 中序表達式
        public string Formula { get; set; }

        // 前序表達式
        public string Prefix { get; set; }

        // 運算結果
        public string Result { get; set; }

        /// <summary>
        /// 繼承單一子類 方便回傳整包資料
        /// </summary>
        //public class NumSingleResult : 
        //{
        //}
    }
}
