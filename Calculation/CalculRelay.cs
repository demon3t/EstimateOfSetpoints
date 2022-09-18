using Calculation.HelperClass;
using Calculation.Interfaces;

namespace Calculation
{
    public class CalculRelay : INominaf_Currents, IVerify_PTN, IDTO
    {
        public enum CalculPower
        {
            Full = 0,
            Falf = 1,
            Custom = 2,
        }

        CalculPower power;

        Transformer transformer;

        public CalculRelay(Transformer _transformer, CalculPower _power)
        {
            transformer = _transformer;
            power = _power;
        }

        public double NominalCurrentHight() // рсчёт наминального тока на стороне ВН
        {
            return transformer.nominalPower / (Math.Sqrt(3) * transformer.nominalHightVoltage) * 1000;
        }

        public double NominalCurrentMedium() // рсчёт наминального тока на стороне СН(НН2)
        {
            return power == CalculPower.Full ?
            transformer.nominalPower / (Math.Sqrt(3) * transformer.nominalMediumVoltage) * 1000 :
            transformer.nominalPower / (Math.Sqrt(3) * 2 * transformer.nominalMediumVoltage) * 1000;
        }

        public double NominalCurrentLower() // рсчёт наминального тока на стороне НН
        {
            return power == CalculPower.Full ?
            transformer.nominalPower / (Math.Sqrt(3) * transformer.nominalLowerVoltage) * 1000 :
            transformer.nominalPower / (Math.Sqrt(3) * 2 * transformer.nominalLowerVoltage) * 1000;
        }

        public bool VerifyPTNHigth() // Проверка ПТН в нагрузочном режиме ВН
        {
            if (PTN.PTNHigth < 2)
                if (PTN.PTNHigth <= 3 * NominalCurrentHight() / TT_Setting.transfCoeffHight) return true;
                else return false;
            else
                if (PTN.PTNHigth <= 6 * NominalCurrentHight() / TT_Setting.transfCoeffHight) return true;
            else return false;
        }

        public bool? VerifyPTNMedium() // Проверка ПТН в нагрузочном режиме СН(НН2)
        {
            if (PTN.PTNMedium == -1)
                return null;

            if (PTN.PTNMedium < 2)
                if (PTN.PTNHigth <= 3 * NominalCurrentMedium() / TT_Setting.transfCoeffmMedium) return true;
                else return false;
            else
                if (PTN.PTNMedium <= 6 * NominalCurrentMedium() / TT_Setting.transfCoeffmMedium) return true;
            else return false;
        }

        public bool VerifyPTNLower() // Проверка ПТН в нагрузочном режиме НН
        {
            if (false == true)  // что за условие?
                if (PTN.PTNLower < 2)
                    if (PTN.PTNLower <= 2 * 3 * NominalCurrentLower() / TT_Setting.transfCoeffLower) return true;
                    else return false;
                else
                    if (PTN.PTNLower <= 2 * 6 * NominalCurrentLower() / TT_Setting.transfCoeffLower) return true;
                else return false;
            else
                if (PTN.PTNLower < 2)
                if (PTN.PTNLower <= 3 * NominalCurrentLower() / TT_Setting.transfCoeffLower) return true;
                else return false;
            else
                    if (PTN.PTNLower <= 6 * NominalCurrentLower() / TT_Setting.transfCoeffLower) return true;
            else return false;
        }

        public double MaximumUnbalanceCurrent() // отстройка от максимального тока небаланса
        {
            double k1;
            if (transformer.settingCountRPNHight == 0) k1 = 0;
            else
                if (0.05 > (transformer.settingCountRPNHight - 1) / 2 * transformer.stepRPNHight / 100) k1 = 0.05;
            else k1 = (transformer.settingCountRPNHight - 1) / 2 * transformer.stepRPNHight / 100;


            double k2;
            if (transformer.settingCountRPNMedium == 0 || (int)transformer.type < 3) k2 = 0;
            else
                if (0.05 > (transformer.settingCountRPNMedium - 1) / 2 * transformer.stepRPNMedium / 100) k2 = 0.05;
            else k2 = (transformer.settingCountRPNMedium - 1) / 2 * transformer.stepRPNMedium / 100;

            double k3;
            if ((int)transformer.type == 1)
                k3 = Currents.LowerToHight;
            else
                if (Currents.MidleToHight > Currents.LowerToHight) k3 = Currents.MidleToHight;
            else k3 = Currents.LowerToHight;

            return Math.Round(1.2 * (2.5 * 1 * TT_Setting.Emax + k1 * 1 + k2 + 0.05) * k3 / NominalCurrentHight(),
                2, MidpointRounding.ToPositiveInfinity);
        }

        public double DTOTriggerSetpoint() // уставка срабатывания ДТО
        {
            if (MaximumUnbalanceCurrent() > DTO.BTN) return MaximumUnbalanceCurrent();
            else return DTO.BTN;
        }
    }
}