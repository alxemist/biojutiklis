using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8.AnalitiniaiSprendiniai
{
    public class AnalitinisSprendinys : ICalculator
    {
        private Constants2 c2;
        public AnalitinisSprendinys(Constants2 c2)
        {
            this.c2 = c2;
        }

        public double Calculate()
        {
            if(c2.S0<c2.Km)
            {
                ICalculator s = new Srove_S0_maziau_uz_km_dvisluoksnis(c2);
                return s.Calculate();
            }
            else
            {
                //ICalculator s = new Srove_S0_daugiau_uz_Km(c);
                //return s.Calculate();
                return 0;
            }
        }
    }
}
