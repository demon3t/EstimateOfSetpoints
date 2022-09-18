using Calculation.HelperClass;
using Calculation.Interfaces;

namespace Calculation
{
    public class CalculRelay : INominaf_Currents, IVerify_PTN, IDTO, IDZT
    {
        public enum CalculPower
        {
            Full = 0,
            Falf = 1,
            Custom = 2,
        }
        public enum TSN
        {
            No = 1,
            Yes = 2
        }

        public enum BMRZ
        {
            First = 1,
            Second = 2
        }

        CalculPower power;
        TSN tsn;
        BMRZ bmrz;

        Transformer transformer;

        public CalculRelay(Transformer transformer, CalculPower power, TSN tsn , BMRZ bmrz)
        {
            this.transformer = transformer;
            this.power = power;
            this.tsn = tsn;
            this.bmrz = bmrz;
        }

        // + 
        #region Расчёт минимальных токов сторон

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

        #endregion
        // + 
        #region Проверка ПТН в нагрузочном режиме

        public bool VerifyPTNHigth() // Проверка ПТН в нагрузочном режиме ВН
        {
            return PTN.PTNHigth < 2 ?
                PTN.PTNHigth <= 3 * NominalCurrentHight() / TT_Setting.transfCoeffHight ? true : false :
                PTN.PTNHigth <= 6 * NominalCurrentHight() / TT_Setting.transfCoeffHight ? true : false;
        }

        public bool? VerifyPTNMedium() // Проверка ПТН в нагрузочном режиме СН(НН2)
        {
            return PTN.PTNMedium == -1? null :
                PTN.PTNMedium < 2?
                PTN.PTNHigth <= 3 * NominalCurrentMedium() / TT_Setting.transfCoeffmMedium? true : false :
                PTN.PTNMedium <= 6 * NominalCurrentMedium() / TT_Setting.transfCoeffmMedium? true : false;
        }

        public bool VerifyPTNLower() // Проверка ПТН в нагрузочном режиме НН
        {
            if ((int)bmrz == 2 && (int)transformer.type == 2)
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

        #endregion
        // +
        #region Расчёт уставок ДТО

        public double MaximumUnbalanceCurrent() // отстройка от максимального тока небаланса
        {
            double k1 = transformer.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (transformer.settingCountRPNHight - 1) / 2 * transformer.stepRPNHight / 100);

            double k2 = transformer.settingCountRPNMedium == 0 || (int)transformer.type < 3 ? 0 :
                Math.Max(0.05, (transformer.settingCountRPNMedium - 1) / 2 * transformer.stepRPNMedium / 100);

            double k3 = (int)transformer.type == 1 ? Currents.LowerToHight :
                Math.Max(Currents.MidleToHight, Currents.LowerToHight);

            return Math.Round(1.2 * (2.5 * 1 * TT_Setting.Emax + k1 * 1 + k2 + 0.05) * k3 / NominalCurrentHight(),
                2, MidpointRounding.ToPositiveInfinity);
        }

        public double DTOTriggerSetpoint() // уставка срабатывания ДТО
        {
            return Math.Max(MaximumUnbalanceCurrent(), DTO.BTN);
        }

        #endregion

        #region "Грубый" орган ДЗТ

        public double Rought_InitialCurrent()
        {
            double result1 = 0.3;
            double result2 = DZT.DZTMinimumInitialCurrent;

            double k3_1 = transformer.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (transformer.settingCountRPNHight - 1) / 2 * transformer.stepRPNHight / 100);

            double k3_2 = transformer.settingCountRPNMedium == 0 || (int)transformer.type < 3 ? 0 :
                Math.Max(0.05, (transformer.settingCountRPNMedium - 1) / 2 * transformer.stepRPNMedium / 100);

            double result3 = Math.Round(1.5 * (1 * 1 * TT_Setting.E0_5 + k3_1 * 1 + k3_2 + 0.05) * 0.5,
                2, MidpointRounding.ToPositiveInfinity);

            double result4 = (int)tsn == 1 ? 0 : Math.Round(1.5 * Currents.MaxCurrentTSN / NominalCurrentHight(),
                2, MidpointRounding.ToPositiveInfinity);

            return Math.Max(result1, Math.Max(result2, Math.Max(result3, result4)));
        }

        public double Rought_InitialCurrent_1_5()
        {
            double k1 = transformer.settingCountRPNHight == 0 ? 0 :
                transformer.settingCountRPNHight < 7 ? 0.5 :
                Math.Max(0.05, 3 * transformer.stepRPNHight / 100);

            double k2 = transformer.settingCountRPNMedium == 0 || (int)transformer.type < 3 ? 0 :
                transformer.settingCountRPNMedium < 7 ? 0.05 :
                Math.Max(0.05, 3 * transformer.settingCountRPNMedium / 100);

            return Math.Round(1.2 * (2 * 1 * TT_Setting.E1_5 + k1 * 1 + k2 * 1 + 0.05) * 1.5
                , 2, MidpointRounding.ToPositiveInfinity);
        }

        public double Rought_SecondDecelerationCoefficient()
        {
            return Math.Round(Math.Max(0.2, Rought_InitialCurrent_1_5() - Rought_InitialCurrent()),
                2, MidpointRounding.ToPositiveInfinity);
        }

        public double Rought_MaxiBrakingCurrent()
        {
            double k1 = (int)transformer.type == 1 ?
                Currents.LowerToHight : Math.Max(Currents.LowerToHight, Currents.MidleToHight);

            return Math.Round((1 * 2.5 * TT_Setting.Emax) * k1
                , 2, MidpointRounding.ToPositiveInfinity);
        }

        public double Rought_ThirdDecelerationCoefficient()
        {
            return Math.Round((MaximumUnbalanceCurrent() - Rought_InitialCurrent_1_5()) / (Rought_MaxiBrakingCurrent() - 1.5),
                2, MidpointRounding.ToPositiveInfinity);
        }

        #endregion

        #region "Чувствительный" орган ДЗТ

        public double Sensitive_InitialCurrent()
        {
            double result1 = 0.3;
            double result2 = DZT.DZTMinimumInitialCurrent;

            double k3_1 = transformer.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (transformer.settingCountRPNHight - 1) / 2 * transformer.stepRPNHight / 100);

            double k3_2 = transformer.settingCountRPNMedium == 0 || (int)transformer.type < 3 ? 0 :
                Math.Max(0.05, (transformer.settingCountRPNMedium - 1) / 2 * transformer.stepRPNMedium / 100);

            double result3 = Math.Round(1.5 * (1 * 1 * TT_Setting.E0_5 + k3_1 * 1 + k3_2 + 0.05) * 0.5,
                2, MidpointRounding.ToPositiveInfinity);

            double result4 = (int)tsn == 1 ? 0 : Math.Round(1.5 * Currents.MaxCurrentTSN / NominalCurrentHight(),
                2, MidpointRounding.ToPositiveInfinity);

            return Math.Max(result1, Math.Max(result2, Math.Max(result3, result4)));
        }

        public double Sensitive_InitialCurrent_1_5()
        {
            double k1 = transformer.settingCountRPNHight == 0 ? 0 :
                transformer.settingCountRPNHight < 7 ? 0.5 :
                Math.Max(0.05, 3 * transformer.stepRPNHight / 100);

            double k2 = transformer.settingCountRPNMedium == 0 || (int)transformer.type < 3 ? 0 :
                transformer.settingCountRPNMedium < 7 ? 0.05 :
                Math.Max(0.05, 3 * transformer.settingCountRPNMedium / 100);

            return Math.Round(1.2 * (2 * 1 * TT_Setting.E1_5 + k1 * 1 + k2 * 1 + 0.05) * 1.5
                , 2, MidpointRounding.ToPositiveInfinity);
        }

        public double Sensitive_SecondDecelerationCoefficient()
        {
            return Math.Round(Math.Max(0.2, Rought_InitialCurrent_1_5() - Rought_InitialCurrent()),
                2, MidpointRounding.ToPositiveInfinity);
        }

        public double Sensitive_MaxiBrakingCurrent()
        {
            double k1 = (int)transformer.type == 1 ?
                Currents.LowerToHight : Math.Max(Currents.LowerToHight, Currents.MidleToHight);

            return Math.Round((1 * 2.5 * TT_Setting.Emax) * k1
                , 2, MidpointRounding.ToPositiveInfinity);
        }

        public double Sensitive_ThirdDecelerationCoefficient()
        {
            return Math.Round((MaximumUnbalanceCurrent() - Rought_InitialCurrent_1_5()) / (Rought_MaxiBrakingCurrent() - 1.5),
                2, MidpointRounding.ToPositiveInfinity);
        }

        public double Sensitive_MaxUnbalanceCurrent()
        {
            return 0;
        }

        #endregion

    }
}