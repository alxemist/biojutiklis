using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator
{
    public class Constants2
    {
        public double Vm;     ///mol/cm3s
        public double Km = 0.0001;    ///mol/cm3
                                         ///
        public double h1;
        public double h2;
        public double h3;
 
        public double r1;
        public double r2;
        public double r3;
        public double FaradayConstant = 96485; ///C/mol
                                         ///
        public double Dpf = 1 * 0.0000000001; ///cm2/s 1 layer
        public double Dpd = 1 * 0.0000001; ///cm2/s 2 layer
                                          //////
        public double Dsf = 1 * 0.0000000001; ///cm2/s  1 layer                                ///
        public double Dsd = 1 * 0.0000001; ///cm2/s  2 layer
                                          ///
        public double d1;
        public double d2;
        public double d3;///cm
        public double N1 = 80;
        public double N2 = 120;
        public double N3 = 120;
        public double ne = 2;
        public double S0 = 1 * 0.00000001;///mol/cm3
        public Constants2(double d1, double d2, double d3, double vm, double S0, double n1, double n2, double n3, double km)
        {
            this.d1 = d1;
            this.d2 = d2;
            this.d3 = d3;
            this.N1 = n1;
            this.N2 = n2;
            this.N3 = n3;
            this.S0 = S0;
            this.Vm = vm;
            this.Km = km;

            h1 = (d1) / N1;
            r1 = (h1 * h1) / (4 * Dsf);

            h2 = (d2) / N2;
            r2 = (h2 * h2) / (4 * Dsd);
        }
    }
}
