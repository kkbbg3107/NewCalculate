﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.InterFace
{
    public interface IStringToList
    {
        List<string> ToListService(string infix);
    }
}
