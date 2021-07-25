﻿using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    /// <summary>
    /// 紀錄按鈕實現方法
    /// </summary>
    public interface IFactory
    {
        IButton UseButton(Calculate cal);
    }
}