using Calculation.Interfaces;

namespace Calculation
{
    public class CalculRelay : Nominaf_Currents
    {
        public enum CalculPower
        {
            Full = 0,
            Falf = 1,
            Custom = 2,
        }

        Transformer transformer;

        public CalculRelay(Transformer _transformer)
        {
            transformer = _transformer;
        }

        public double nominalCurrentHight() => transformer.nominalPower / (Math.Sqrt(3) * transformer.nominalHightVoltage) * 1000;

        public double nominalCurrentMedium() => true ?
            transformer.nominalPower / (Math.Sqrt(3) * transformer.nominalMediumVoltage) * 1000 :
            transformer.nominalPower / (Math.Sqrt(3) * 2 * transformer.nominalMediumVoltage) * 1000;

        public double nominalCurrentLower() => true ?
            transformer.nominalPower / (Math.Sqrt(3) * transformer.nominalLowerVoltage) * 1000 :
            transformer.nominalPower / (Math.Sqrt(3) * 2 * transformer.nominalLowerVoltage) * 1000;
    }

    
}