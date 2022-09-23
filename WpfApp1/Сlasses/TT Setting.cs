using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    public static class TT_Setting
    {
        public static double transfCoeffHight { get; set; } = 80;
        public static double transfCoeffmMedium { get; set; } = 300;
        public static double transfCoeffLower { get; set; } = 600;

        public static double Emax { get; set; } = 0.1;
        public static double Emin { get; set; } = 0.1;
        public static double E0_5 { get; set; } = 0.1;
        public static double Erab_max { get; set; } = 0.1;
        public static double E1_5 { get; set; } = 0.1;
    }
}
