using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator
{
    public class Substract : Material
    {
        public double Value { get; set; }
        public Substract(double value)
        {
            Value= value;
        }
    }
}
