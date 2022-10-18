using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    internal static class Currents_TT
    {
        internal static double MaxCurrentHightKZToHight { get; private set; } = 4427;
        internal static double MaxCurrentMildleKZToHight { get; private set; } = 1729;
        internal static double MaxCurrentLowerKZToHight { get; private set; } = 1541;
        internal static double MinCurrentOtherKZToHight { get; private set; } = 392;

        internal static double MaxCurrentTSN { get; private set; } = 0;
        internal static double WorkCurrentTSN { get; private set; } = 0;
        internal static void Set_MaxCurrentTSN(double value) => MaxCurrentTSN = value;
        internal static void Set_WorkCurrentTSN(int value) => WorkCurrentTSN = value;
    }
}
