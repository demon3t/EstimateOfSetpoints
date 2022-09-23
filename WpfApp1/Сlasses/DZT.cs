using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.HelperClass
{
    public static class DZT
    {
        public static double DZTMinimumInitialCurrent { get; private set; } = 0.3;
        public static void Set_DZTMinimumInitialCurrent(double value) => DZTMinimumInitialCurrent = value;
    }
}
