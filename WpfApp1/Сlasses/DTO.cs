using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.HelperClass
{
    public static class DTO
    {
        public static double BTN { get; private set; } = 4;

        public static void Set_BTN(double value) => BTN = value;
    }
}
