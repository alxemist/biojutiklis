using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosensorSensitivityCalculator
{
    public interface IProduct
    {
         //Product getProduct(Key key);
         //Product getProduct(Key key, bool val);
         double calculateProduct(int j);
         double calculateOldProduct(int j);
    }
}
