﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public interface IIsPointClose
    {
       bool IsPointClose(double Xi, double Yi,double precision);
    }
}
