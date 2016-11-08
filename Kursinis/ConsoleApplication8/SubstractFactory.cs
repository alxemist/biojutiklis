using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator
{
    public class SubstractFactory
    {
        //private Dictionary<string, Substract> s = new Dictionary<string, Substract>();
        private Dictionary<string, Substract> s1 = new Dictionary<string, Substract>();
        private Dictionary<string, Substract> s2 = new Dictionary<string, Substract>();
        //private Dictionary<string, Substract> s3 = new Dictionary<string, Substract>();
        //private Constants c;
        public Constants2 c2;
        // Constructor with conditions
        public SubstractFactory(Constants2 co2)
        {
            //c = constants;
            c2 = co2;
            for (int i = 0; i < Convert.ToInt32(c2.N1); i++)
            {
                s1.Add(new Key(i, 0).getKey(), new Substract(0));
            }

            for (int i = 1; i < Convert.ToInt32(c2.N2); i++)
            {
                s2.Add(new Key(i, 0).getKey(), new Substract(0));
            }
            s2.Add(new Key(Convert.ToInt32(c2.N2), 0).getKey(), new Substract(c2.S0));
            s1.Add(new Key(Convert.ToInt32(c2.N1), 0).getKey(), new Substract(0));
            s2.Add(new Key(0, 0).getKey(), new Substract(0));

        }

        // Gets substract using it's possition and layer
        public Substract getNewSubstract(Key key, int layer)
        {
            Substract substract = null;
            if (layer == 1)
            {
                substract = s1[key.getKey()];
            }
            if (layer == 2)
            {
                substract = s2[key.getKey()];
            }
            return substract;
        }

        // Calculates product at point between layers
        private double calculate(int j, double N, double h1, double h2)
        {
            double value;
            Substract pro1;
            Substract pro2;

            pro1 = s1[new Key(Convert.ToInt32(N) - 1, j).getKey()]; // n-1
            pro2 = s2[new Key(1, j).getKey()]; // n+1
            //Dsd = Dsm
            //Dsf = Dse

            value = (c2.Dsf * h2 * pro1.Value + c2.Dsd * h1 * pro2.Value) / (c2.Dsf * h2 + c2.Dsd * h1);
            //Console.WriteLine(pro2.Value);
            return value;

        }

        // Substract solution
        public void calculateSubstract(int j)
        {
            /*try
            {
                calculate_d3(j);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+"sub3");
            }*/
            try
            {
                calculate_d2(j);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "sub2");
            }           
            try
            {
                calculate_d1(j);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"sub1");
            }
            try
            {
                double value = calculate(j, c2.N1, c2.h1, c2.h2);


                s1.Add(new Key(Convert.ToInt32(c2.N1), j).getKey(), new Substract(value)); //value
                s2.Add(new Key(0, j).getKey(), new Substract(value)); //value
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "other");
            }
        }

        // Calculates substract at layer d2
        public void calculate_d2(int j)
        {
            for (int i = Convert.ToInt32(c2.N2); i > 0; i--)
            {
                Substract val1;
                Substract val2;
                Substract val3;
                if (i == Convert.ToInt32(c2.N2)) 
                {
                    s2.Add(new Key(i, j).getKey(), new Substract(c2.S0));
                }
                else
                {
                    val1 = s2[new Key(i + 1, j - 1).getKey()];
                    val2 = s2[new Key(i, j - 1).getKey()];
                    val3 = s2[new Key(i - 1, j - 1).getKey()];

                    double value = c2.Dsd * (val1.Value - 2 * val2.Value + val3.Value) * c2.r2 / (c2.h2 * c2.h2)
                        //- c2.Vm * val2.Value * c2.r2 / (c2.Km + val2.Value)
                        + val2.Value;
                        
                    s2.Add(new Key(i, j).getKey(), new Substract(value));

                }
            }
        }

        // Calculates substract at layer d1
        public void calculate_d1(int j)
        {
            for (int i = Convert.ToInt32(c2.N1); i >= 0; i--)
            {
                Substract val1;
                Substract val2;
                Substract val3;
                if (i == Convert.ToInt32(c2.N1))
                {

                }
                else
                {
                    if (i == 0)
                        {
                            i = 1;
                            val1 = s1[new Key(i, j).getKey()];
                           
                            s1.Add(new Key(i - 1, j).getKey(), val1);
                            i = 0;
                            
                        }
                    else
                    {
                        val1 = s1[new Key(i + 1, j - 1).getKey()];
                        val2 = s1[new Key(i, j - 1).getKey()];
                        val3 = s1[new Key(i - 1, j - 1).getKey()];


                        double value = c2.Dsf * (val1.Value - 2 * val2.Value + val3.Value) * c2.r1 / (c2.h1 * c2.h1)
                            - c2.Vm * val2.Value * c2.r1 / (c2.Km + val2.Value)
                            + val2.Value;
                        s1.Add(new Key(i, j).getKey(), new Substract(value));
                    }

                }
            }
        }
    }
}
