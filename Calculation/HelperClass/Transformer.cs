using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    public class Transformer
    {
        public Transformer(double _nominalPower, double _nominalHightVoltage, double _nominalMediumVoltage, double _nominalLowerVoltage,
            int _settingCountRPNHight, double _stepRPNHight, int _settingCountRPNMedium, double _stepRPNMedium)
        {
            nominalPower = _nominalPower;
            nominalHightVoltage = _nominalHightVoltage;
            nominalMediumVoltage = _nominalMediumVoltage;
            nominalLowerVoltage = _nominalLowerVoltage;
            settingCountRPNHight = _settingCountRPNHight;
            stepRPNHight = _stepRPNHight;
            settingCountRPNMedium = _settingCountRPNMedium;
            stepRPNMedium = _stepRPNMedium;
        }

        public double nominalPower { get; set; }
        public double nominalHightVoltage { get; set; }
        public double nominalMediumVoltage { get; set; }
        public double nominalLowerVoltage { get; set; }

        public int settingCountRPNHight { get; set; }
        public double stepRPNHight { get; set; }

        public int settingCountRPNMedium { get; set; }
        public double stepRPNMedium { get; set; }
    }
}
