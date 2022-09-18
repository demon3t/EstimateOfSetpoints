using Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.HelperClass
{
    public static class Currents
    {
        public static double MaxCurrentHight { get; private set; } = 4427;
        public static double MaxCurrentMildle { get; private set; } = 4514;
        public static double MaxCurrentLower { get; private set; } = 14177;
        public static void Set_MaxCurrentHight(double value) => MaxCurrentHight = value;
        public static void Set_MaxCurrentMildle(double value) => MaxCurrentMildle = value;
        public static void Set_MaxCurrentLower(double value) => MaxCurrentLower = value;

        public static double MinCurrentOtherKZ { get; private set; } = 392;
        public static void Set_MinCurrentOtherKZ(double value) => MinCurrentOtherKZ = value;


        public static double HigthToHight { get; private set; } = 4427;
        public static double MidleToHight { get; private set; } = 1729;
        public static double LowerToHight { get; private set; } = 1541;
        public static void Set_HigthToHight(double value) => HigthToHight = value;
        public static void Set_MidleToHight(double value) => MidleToHight = value;
        public static void Set_LowerToHight(double value) => LowerToHight = value;


        public static double MaxCurrentTSN { get; private set; } = 0;
        public static double WorkCurrentTSN { get; private set; } = 0;
        public static void Set_MaxCurrentTSN(double value) => MaxCurrentTSN = value;
        public static void Set_WorkCurrentTSN(int value) => WorkCurrentTSN = value;

    }
}
