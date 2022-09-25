using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public static class Transformer
    {
        public enum TypeTransformer
        {
            Double = 1,
            Split = 2,
            Triple = 3
        }

        static Transformer()
        {

        }
        public static TypeTransformer type { get; set; }

        public static double nominalPower { get; set; } = 40;
        public static double nominalHightVoltage { get; set; } = 115;
        public static double nominalMediumVoltage { get; set; } = 38.5;
        public static double nominalLowerVoltage { get; set; } = 11;

        public static int settingCountRPNHight { get; set; } = 19;
        public static double stepRPNHight { get; set; } = 1.78;

        public static int settingCountRPNMedium { get; set; } = 5;
        public static double stepRPNMedium { get; set; } = 2.5;
    }
}
