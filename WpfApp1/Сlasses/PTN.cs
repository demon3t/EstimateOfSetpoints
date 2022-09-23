using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.HelperClass
{
    public static class PTN
    {
        public static double PTNHigth { get; set; } = 1;
        public static double PTNMedium { get; set; } = 0.5;
        public static double PTNLower { get; set; } = 0.5;

        public static void Set_PTNHigth(double value) => PTNHigth = value;
        public static void Set_PTNMedium(double value) => PTNMedium = value;
        public static void Set_PTNLower(double value) => PTNLower = value;
    }
}
