namespace Calculation
{
    public class CalculRelay
    {
        public enum CalculPower
        {
            Full = 0,
            Falf = 1,
            Custom = 2,
        }
        public double nominalPower { get; set; }
        public double nominalHightVoltage { get; set; }
        public double nominalMediumVoltage { get; set; }
        public double nominalLowerVoltage { get; set; }

        public int settingCountRPNHight { get; set; }
        public double stepRPNHight { get; set; }

        public int settingCountRPNMedium { get; set; }
        public double stepRPNMedium { get; set; }

        public double transfCoeffHight { get; set; }
        public double transfCoeffmMedium { get; set; }
        public double transfCoeffLower { get; set; }

    }
}