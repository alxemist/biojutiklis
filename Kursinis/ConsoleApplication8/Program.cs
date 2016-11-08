using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosensorSensitivityCalculator.ExportToExcel;

namespace BiosensorSensitivityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<double> stack_S0 = new Stack<double>();
            Stack<double> stack_Electricity = new Stack<double>();
            Stack<double> stack_ElectricityOld = new Stack<double>();
            double value1;
            double value2;
            double value12;
            double value22;

            ///                  Constants:   d,      Vm,       S0

           // Constants c4 = new Constants(0.0008, 0.000001, 0.00000002);
            ///                    Constants:   d1,      d2,     d3,      Vm        S0       N1  N2   N3
           // Constants2 c01 = new Constants2(0.0008, 0.00001, 0.0004, 0.000001, 0.00000001, 80, 40, 120);

            /*double S0 = 0.000001;
            double d1 = 0.000008;
            double d2 = 0.000002;
            double Vm = 0.1;*/
            // Difference between S0
            double dif = 0.001;
            // public double Km = 0.0001;    ///mol/cm3


            double S01 = 0.000000001;

            /*for (int i = 0; i <= 60; i++)
            {
                value1 = countOld(d1, d2, Vm, S01);
                Constants2 c01 = new Constants2(d1, d2, 0.0004, Vm, S01, 80, 40, 120);
                ElectricityOld electricity1 = new ElectricityOld(new NewProduct(c01), c01);
                value12 = electricity1.getAnalyticCalculation();
                stack_Electricity.Push(value1);
                stack_ElectricityOld.Push(value12);
                stack_S0.Push(S01);
                S01 += 0.000000002;
                Console.WriteLine(i);
            }*/

            /*Console.WriteLine("Real solution:     "+value1);
            Console.WriteLine("Analitic solution  "+value12);
            Console.ReadLine();*/



            /*for (int i = 0; i <= 64; i++)
            {
                Console.WriteLine("*************Start: "+i+" **************");
                value1 = count(d1, d2, Vm, S0);
                Console.WriteLine("Firsl value: "+value1);
                value12 = count(d1, d2, Vm, S0+S0*dif);
                Console.WriteLine("Second value: "+value12);
                stack_Electricity.Push((value12 - value1) * (S0 + S0*dif) / (( S0 + S0 * dif - S0 ) * value12));
                Console.WriteLine("Biosensor sensitivity: "+stack_Electricity.Peek());
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
                value2 = countOld(d1, d2, Vm, S0);
                Console.WriteLine("First value: " + value2);
                value22 = countOld(d1, d2, Vm, S0+S0*dif);
                Console.WriteLine("Second value: " + value22);
                stack_ElectricityOld.Push((value22 - value2) * (S0 + S0 * dif) / ((S0 + S0 * dif - S0) * value22));
                Console.WriteLine("Biosensor sensitivity: " + stack_ElectricityOld.Peek());
                stack_S0.Push(S0);
                S0 = S0 * 1.2;
                Console.WriteLine("*************End: " + i + " **************");
                Console.WriteLine("Difference between sensitivities: " + (stack_Electricity.Peek()-stack_ElectricityOld.Peek()));
            }
            
            ExcelExporter ex = new ExcelExporter();
            ex.ExportS0Electricitry(stack_S0,stack_Electricity, stack_ElectricityOld);

            Console.ReadLine();*/
            /* d1 values */
            List<double> d1_List = new List<double>();
            d1_List.Add(0.1);
            d1_List.Add(0.001);
            d1_List.Add(0.00001);
            d1_List.Add(0.0000001);
            //d1_List.Add(0.000000001);
            // d2 values
            List<double> d2_List = new List<double>();
            d2_List.Add(0.1);
            d2_List.Add(0.001);
            d2_List.Add(0.00001);
            //d2_List.Add(0.0000001);
            d2_List.Add(0.0000001);
            // Vm values
            List<double> Vm_List = new List<double>();
            Vm_List.Add(1);
            Vm_List.Add(0.01);
            Vm_List.Add(0.0001);
            Vm_List.Add(0.000001);
           // Vm_List.Add(0.00000001);
            // Km values
            List<double> Km_List = new List<double>();
            Km_List.Add(1);
            Km_List.Add(0.01);
            Km_List.Add(0.0001);
            Km_List.Add(0.000001);
            //Km_List.Add(0.00000001);
            // S0 values
            List<double> S0_List = new List<double>();
            S0_List.Add(1);
            S0_List.Add(0.01);
            S0_List.Add(0.0001);
           // S0_List.Add(0.000001);
            S0_List.Add(0.00000001);


            int i = 0;

            ExcelExporter ex = new ExcelExporter();
            // Calculations
            foreach (var d1 in d1_List)
            {
                foreach (var d2 in d2_List)
                {
                    foreach (var Km in Km_List)
                    {
                        foreach (var Vm in Vm_List)
                        {
                            foreach (var S0 in S0_List)
                            {
                                if (i >= 0)
                                {
                                    /**/
                                    Console.WriteLine("*************Start: " + i + " **************");
                                    value1 = count(d1, d2, Vm, S0, Km);
                                    Console.WriteLine("First value: " + value1);
                                    value12 = count(d1, d2, Vm, S0 + S0 * dif, Km);
                                    Console.WriteLine("Second value: " + value12);
                                    stack_Electricity.Push((value12 - value1) * (S0 + S0 * dif) / ((S0 + S0 * dif - S0) * value12));
                                    Console.WriteLine("Biosensor sensitivity: " + stack_Electricity.Peek());
                                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
                                    value2 = countOld(d1, d2, Vm, S0, Km);
                                    Console.WriteLine("First value: " + value2);
                                    value22 = countOld(d1, d2, Vm, S0 + S0 * dif, Km);
                                    Console.WriteLine("Second value: " + value22);
                                    stack_ElectricityOld.Push((value22 - value2) * (S0 + S0 * dif) / ((S0 + S0 * dif - S0) * value22));
                                    Console.WriteLine("Biosensor sensitivity: " + stack_ElectricityOld.Peek());
                                    //stack_S0.Push(S0);
                                    Console.WriteLine("*************End: " + i + " **************");
                                    Console.WriteLine("Difference between sensitivities: " + (stack_Electricity.Peek() - stack_ElectricityOld.Peek()));
                                    
                                    ex.ExportOneResult(S0, stack_Electricity.Pop(), stack_ElectricityOld.Pop(), d1, d2, Vm, Km);
                                    /**/
                                }
                                i++;
                            }
                        }
                    }
                }
            }
            

            Console.ReadLine();

        }

        static double count(double d1, double d2, double Vm, double S0, double Km)
        {
            Constants2 c01 = new Constants2(d1, d2, 0.0004, Vm, S0, 40, 40, 120, Km);
            Electricity electricity1 = new Electricity(new NewProduct(c01), c01);
            double value1 = electricity1.calculate();
            electricity1 = null;


            return value1;
        }

        static double countOld(double d1, double d2, double Vm, double S0, double Km)
        {
            Constants2 c01 = new Constants2(d1, d2, 0.0004, Vm, S0, 40, 40, 120, Km);
            ElectricityOld electricity1 = new ElectricityOld(new NewProduct(c01), c01);
            double value1 = electricity1.calculate();
            electricity1 = null;


            return value1;
        }
    }
}
