﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator
{
    public class Product : Material
    {
        public double Value { get; set; }
        public Product(double value)
        {
            Value = value;
        }
    }
}
