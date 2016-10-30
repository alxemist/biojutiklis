using ConsoleApplication8.AnalitiniaiSprendiniai;
using ConsoleApplication8.ExportToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public class ElectricityOld
    {
        private IProduct p;
        public Constants2 c2;
        public double Time { get; set; }
        public ElectricityOld(IProduct product, Constants2 constants2)
        {
            p = product;
            c2 = constants2;
            
        }
        //private double calculateI(int j)
        //{
        //    return c.ne * c.Dp * c.Faradejus * (p.getProduct(new Key(1, j)).Value-p.getProduct(new Key(0,j)).Value)/c.h;
        //}
        //private double calculateI(int j, bool factor)
        //{
        //    return c.ne * c.Dp * c.Faradejus * (p.getProduct(new Key(1, j), true).Value - p.getProduct(new Key(0, j), true).Value) / c.h;
        //}
        private double calculate2(int j)
        {
            return c2.ne * c2.Dpf * c2.Faradejus * (p.calculateOldProduct(j)) / c2.h1;
        }
        public double calculate()
        {
            Stack<double> stack = new Stack<double>();
            Stack<double> timeStack = new Stack<double>();
            int j = 1;
            double value = 0;
            bool check = false;
            try
            {
                value = calculate2(j);
                stack.Push(value);
                /*timeStack.Push(j * c.r);*/
                j++;
                while (check == false)
                {
                    value = calculate2(j);
                    if ((value - stack.Peek()) / value < 0.0000000001)
                    {
                        check = true;
                    } 
                    stack.Pop();
                    stack.Push(value);
                    /*timeStack.Push(j * c.r);*/
                    //Console.WriteLine(stack.Peek());
                    j++;
                }
                //ExcelExporter ex = new ExcelExporter();
                /*ex.Export(stack, timeStack);*/
                //Time=(j-1)*c2.r1;
                return stack.Peek();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"E");
                return 0;
            }
        }
        public double getAnalyticCalculation()
        {
            ICalculator sprendinys = new AnalitinisSprendinys(c2);
            return sprendinys.Calculate();
        }
    }
}
