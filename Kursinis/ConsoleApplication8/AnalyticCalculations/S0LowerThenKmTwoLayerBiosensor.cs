using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator.AnalyticCalculations
{
    public class S0LowerThenKmTwoLayerBiosensor : ICalculator
    {
        private Constants2 c2;
        public S0LowerThenKmTwoLayerBiosensor(Constants2 c2)
        {
            this.c2 = c2;
        }
        public double Calculate()
        {
            double x = Math.Sqrt(c2.Vm * c2.d1 * c2.d1 / (c2.Dsf * c2.Km));
            return c2.ne*c2.FaradayConstant*c2.Dpf*c2.S0*(1/(c2.d1+c2.d2))*
                (c2.d1 + c2.d2 * (c2.Dsd - x * c2.Dsf * Math.Sinh(x) / Math.Cosh(x)) / (c2.Dsd + x*c2.Dsf * Math.Sinh(x) / Math.Cosh(x)))
                * (c2.d2 * c2.d1 * c2.Vm * Math.Sinh(x) / (Math.Cosh(x) * x * c2.Km) + c2.Dsf * c2.Dpd / c2.Dpf * (1 - 1 / Math.Cosh(x)))
                /(c2.Dpd*c2.d1+c2.Dpf*c2.d2);
        }
    }
}
