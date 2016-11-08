using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator
{
    public class NewProduct : IProduct
    {
        private Dictionary<string, Product> p1 = new Dictionary<string, Product>();
        private Dictionary<string, Product> p2 = new Dictionary<string, Product>();
        private SubstractFactory s;
        //private Constants c;
        private Constants2 c2;
        // Constructor with conditions
        public NewProduct(Constants2 co2)
        {
            c2 = co2;
            s = new SubstractFactory(co2);
            
            for (int i = 0; i <= Convert.ToInt32(c2.N2); i++)
            {
                p2.Add(new Key(i, 0).getKey(), new Product(0));
            }
            

            for (int i = 0; i <= Convert.ToInt32(c2.N1); i++)
            {
                p1.Add(new Key(i, 0).getKey(), new Product(0));
            }
            
        }
        // Calculates product at point between layers
        private double calculate(int j, double N, double h1, double h2)
        {
            double value;
            Product pro1;
            Product pro2;

            pro1 = p1[new Key(Convert.ToInt32(N) - 1, j).getKey()];
            pro2 = p2[new Key(1, j).getKey()];



            value = (c2.Dpf * h2 * pro1.Value + c2.Dpd * h1 * pro2.Value) / (c2.Dpf * h2 + c2.Dpd * h1);

            return value;

        }

        // Product solution with membrane
        public double calculateOldProduct(int j)
        {
            try
            {
                s.calculateSubstract(j);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "prod1");
                return 1000;
            }
            try
            {
                Product final_product;
                double value;
                ///calculate_d3(j);
                calculate_d2(j);
                calculate_d1(j);

                value = calculate(j, c2.N1, c2.h1, c2.h2);
                


                p1.Add(new Key(Convert.ToInt32(c2.N1), j).getKey(), new Product(value));
                p2.Add(new Key(0, j).getKey(), new Product(value));

                final_product = p1[new Key(1, j).getKey()];
                return final_product.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "prod2");
                return 1;
            }
        }

        // Solution with membrane but with no flux of product through d1 and d2 boundary
        public double calculateProduct(int j)
        {
            try
            {
                s.calculateSubstract(j);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+"prod1");
                return 1000;
            }
            try
            {
                Product final_product;
                calculate_d2(j);
                calculate_d1(j);

                Product val1 = p1[new Key(Convert.ToInt32(c2.N1) - 1, j).getKey()];

               

                p1.Add(new Key(Convert.ToInt32(c2.N1), j).getKey(), val1); //val1
                p2.Add(new Key(0, j).getKey(), val1); //val1


                final_product = p1[new Key(1, j).getKey()];
                return final_product.Value;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "prod2");
                return 1;
            }
        }


        // Calculates product at layer d2
        public void calculate_d2(int j)
        {
            for (int i = Convert.ToInt32(c2.N2); i > 0; i--)
            {
                Product val1;
                Product val2;
                Product val3;
                Substract sub1;
                if (i == Convert.ToInt32(c2.N2))
                {
                    p2.Add(new Key(i, j).getKey(), new Product(0));
                }
                else
                {
                    val1 = p2[new Key(i + 1, j - 1).getKey()];
                    val2 = p2[new Key(i, j - 1).getKey()];
                    val3 = p2[new Key(i - 1, j - 1).getKey()];

                    sub1 = s.getNewSubstract(new Key(i, j - 1),2);

                    double value = c2.Dpd * (val1.Value - 2 * val2.Value + val3.Value) * c2.r2 / (c2.h2 * c2.h2)
                        //+ c2.Vm * sub1.Value * c2.r2 / (c2.Km + sub1.Value)
                        + val2.Value;
                        
                    p2.Add(new Key(i, j).getKey(), new Product(value));

                }
            }
        }

        // Calculates product at layer d1
        public void calculate_d1(int j)
        {
            Product val1;
            Product val2;
            Product val3;
            Substract sub1;
            for (int i = Convert.ToInt32(c2.N1); i >= 0; i--)
            {
                if (i == Convert.ToInt32(c2.N1))
                {
                    
                }
                else
                {
                    if (i == 0)
                    {
                        p1.Add(new Key(i, j).getKey(), new Product(0));
                    }
                    else
                    {
                        
                            val1 = p1[new Key(i + 1, j - 1).getKey()];
                            val2 = p1[new Key(i, j - 1).getKey()];
                            val3 = p1[new Key(i - 1, j - 1).getKey()];

                            sub1 = s.getNewSubstract(new Key(i, j - 1),1);

                            double value = c2.Dpf * (val1.Value - 2 * val2.Value + val3.Value) * c2.r1 / (c2.h1 * c2.h1)
                                + c2.Vm * sub1.Value * c2.r1 / (c2.Km + sub1.Value)
                                + val2.Value;
                            p1.Add(new Key(i, j).getKey(), new Product(value));
                      
                    }
                }
            }
            /*val1 = p1[new Key(Convert.ToInt32(c2.N1) - 2, j).getKey()];
            p1.Add(new Key(Convert.ToInt32(c2.N1) - 1, j).getKey(), val1);*/
        }
    }
}
