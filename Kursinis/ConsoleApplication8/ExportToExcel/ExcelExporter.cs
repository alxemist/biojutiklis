using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace BiosensorSensitivityCalculator.ExportToExcel
{
    public class ExcelExporter
    {
        private Microsoft.Office.Interop.Excel._Application xls;
        private Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
        private Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;

        private int i = 2;
        public ExcelExporter()
        {
            xls = new Microsoft.Office.Interop.Excel.Application();
            if (xls == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }
            xlWorkbook = xls.Workbooks.Add(XlSheetType.xlWorksheet);
            xlWorksheet = (Worksheet)xls.ActiveSheet;

            xlWorksheet.Cells[1, 7] = "Nepralaidi plevele";
            xlWorksheet.Cells[1, 6] = "Pralaidi plevele";
            xlWorksheet.Cells[1, 5] = "S0";
            xlWorksheet.Cells[1, 4] = "Km";
            xlWorksheet.Cells[1, 3] = "Vm";
            xlWorksheet.Cells[1, 2] = "d2";
            xlWorksheet.Cells[1, 1] = "d1";

            xls.Visible = true;


        }
        /*public void Export(Stack<double> stack, Stack<double> timeStack)
        {
            Microsoft.Office.Interop.Excel._Application xls;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;

            xls = new Microsoft.Office.Interop.Excel.Application();
            if (xls == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }
            xlWorkbook = xls.Workbooks.Add(XlSheetType.xlWorksheet);
            xlWorksheet = (Worksheet)xls.ActiveSheet;

            xlWorksheet.Cells[1, 1] = "Laikas";
            xlWorksheet.Cells[1, 2] = "Reiksme";
            Stack<double> stack2 = new Stack<double>(stack);
            Stack<double> timeStack2 = new Stack<double>(timeStack);
            int i = 2;
            try
            {
                while(stack.Count!=0 || timeStack.Count!=0)
                {
                    xlWorksheet.Cells[i, 2] = stack2.Pop();
                    xlWorksheet.Cells[i, 1] = timeStack2.Pop();
                    i++;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message+ " Excel ");
            }
            finally
            {
                xls.Visible = true;
            }
            

        }*/

        /*public void ExportS0Electricitry(Stack<double> s0, Stack<double> electricity, Stack<double> electricityOld)
        {
            Microsoft.Office.Interop.Excel._Application xls;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;

            xls = new Microsoft.Office.Interop.Excel.Application();
            if (xls == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }
            xlWorkbook = xls.Workbooks.Add(XlSheetType.xlWorksheet);
            xlWorksheet = (Worksheet)xls.ActiveSheet;

            xlWorksheet.Cells[1, 3] = "S0_su_plevele";
            xlWorksheet.Cells[1, 2] = "S0_be_pleveles";
            xlWorksheet.Cells[1, 1] = "Srovė";
            Stack<double> stack2 = new Stack<double>(s0);
            Stack<double> timeStack2 = new Stack<double>(electricity);
            Stack<double> electricity2 = new Stack<double>(electricityOld);
            int i = 2;
            try
            {
                while (stack2.Count != 0 || timeStack2.Count != 0 || electricity2.Count != 0)
                {
                    xlWorksheet.Cells[i, 3] = timeStack2.Pop();
                    xlWorksheet.Cells[i, 2] = electricity2.Pop();
                    xlWorksheet.Cells[i, 1] = stack2.Pop();
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excel error");
            }
            finally
            {
                xls.Visible = true;
            }
        }*/

        public void ExportOneResult(double S0, double electricity, double oldElectricity,
            double d1, double d2, double Vm, double Km)
        {

            xlWorksheet.Cells[i, 7] = electricity;
            xlWorksheet.Cells[i, 6] = oldElectricity;
            xlWorksheet.Cells[i, 5] = S0;
            xlWorksheet.Cells[i, 4] = Vm;
            xlWorksheet.Cells[i, 3] = Km;
            xlWorksheet.Cells[i, 2] = d2;
            xlWorksheet.Cells[i, 1] = d1;
            i++;
        }

        /*public void ExportS0Electricitry(Stack<double> s0, Stack<double> electricity, Stack<double> electricityOld, 
            List<double> d1_List, List<double> d2_List, List<double> Vm_List, List<double> Km_List, List<double> S0_List)
        {
            Microsoft.Office.Interop.Excel._Application xls;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;

            xls = new Microsoft.Office.Interop.Excel.Application();
            if (xls == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }
            xlWorkbook = xls.Workbooks.Add(XlSheetType.xlWorksheet);
            xlWorksheet = (Worksheet)xls.ActiveSheet;

            xlWorksheet.Cells[1, 7] = "Nepralaidi plevele";
            xlWorksheet.Cells[1, 6] = "Pralaidi plevele";
            xlWorksheet.Cells[1, 5] = "S0";
            xlWorksheet.Cells[1, 4] = "Km";
            xlWorksheet.Cells[1, 3] = "Vm";
            xlWorksheet.Cells[1, 2] = "d2";
            xlWorksheet.Cells[1, 1] = "d1";
            Stack<double> stack2 = new Stack<double>(s0);
            Stack<double> timeStack2 = new Stack<double>(electricity);
            Stack<double> electricity2 = new Stack<double>(electricityOld);
            int i = 2;
            try
            {
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
                                    
                                    xlWorksheet.Cells[i, 7] = timeStack2.Pop();
                                    xlWorksheet.Cells[i, 6] = electricity2.Pop();
                                    xlWorksheet.Cells[i, 5] = stack2.Pop();
                                    xlWorksheet.Cells[i, 4] = Vm;
                                    xlWorksheet.Cells[i, 3] = Km;
                                    xlWorksheet.Cells[i, 2] = d2;
                                    xlWorksheet.Cells[i, 1] = d1;
                                    i++;
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excel error");
            }
            finally
            {
                xls.Visible = true;
            }
        }*/
    }
}
