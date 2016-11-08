using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public class Key
    {
        public int I { get; set; }
        public int J { get; set; }

        public Key(int i, int j)
        {
            I = i;
            J = j;
        }
        public string getKey()
        {
            return Convert.ToString(I) + "," + Convert.ToString(J);
        }

    }
}
