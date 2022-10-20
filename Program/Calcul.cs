using System;

namespace Program
{
    internal static class Calcul
    {

        internal static int round { get; set; } = 2;
        internal enum BMRZ
        {
            First = 1,
            Second = 2
        }
        internal static BMRZ bmrz = BMRZ.First;

        public enum Power
        {
            Full = 0,
            Falf = 1,
        }
        internal static Power power = Power.Full;

        internal static double NominalCurrentHight { get; private set; }
        internal static double NominalCurrentMedium { get; private set; }
        internal static double NominalCurrentLower { get; private set; }
        internal static string NominalCurrentHightPTN { get; private set; }
        internal static string NominalCurrentMediunPTN { get; private set; }
        internal static string NominalCurrentLowerPTN { get; private set; }


        internal static double MaximumUnbalanceCurrent { get; private set; }
        internal static double DTOTriggerSetpoint { get; private set; }


        internal static double Rought_InitialCurrent { get; private set; }
        internal static double Rought_InitialCurrent_1_5 { get; private set; }
        internal static double Rought_SecondDecelerationCoefficient { get; private set; }
        internal static double Rought_MaxiBrakingCurrent { get; private set; }
        internal static double Rought_ThirdDecelerationCoefficient { get; private set; }


        internal static double Sensitive_InitialCurrent { get; private set; }
        internal static double Sensitive_InitialCurrent_1_5 { get; private set; }
        internal static double Sensitive_SecondDecelerationCoefficient { get; private set; }
        internal static double Sensitive_MaxUnbalanceCurrent { get; private set; }
        internal static double Sensitive_ThirdDecelerationCoefficient { get; private set; }

        internal static double SensitivityCoefficient { get; private set; }
        internal static double UnbalanceAlarmRate { get; private set; }

        internal static void Go()
        {
            #region Номинатьные токи сторон

            NominalCurrentHight = Math.Round(TransformerData.nominalPower / (Math.Sqrt(3) * TransformerData.nominalHightVoltage) * 1000, 2, MidpointRounding.ToPositiveInfinity);

            NominalCurrentMedium = power == Power.Full ?
            Math.Round(TransformerData.nominalPower / (Math.Sqrt(3) * TransformerData.nominalMediumVoltage) * 1000, round, MidpointRounding.ToPositiveInfinity) :
            Math.Round(TransformerData.nominalPower / (Math.Sqrt(3) * 2 * TransformerData.nominalMediumVoltage) * 1000, round, MidpointRounding.ToPositiveInfinity);

            NominalCurrentLower = power == Power.Full ?
            Math.Round(TransformerData.nominalPower / (Math.Sqrt(3) * TransformerData.nominalLowerVoltage) * 1000, round, MidpointRounding.ToPositiveInfinity) :
            Math.Round(TransformerData.nominalPower / (Math.Sqrt(3) * 2 * TransformerData.nominalLowerVoltage) * 1000, round, MidpointRounding.ToPositiveInfinity);

            #endregion

            #region ПТН

            NominalCurrentHightPTN = 2 * Currents.MaxCurrentHightKZ / TT.transfCoeffHight < 65 ?
                "0,5" : 2 * Currents.MaxCurrentHightKZ / TT.transfCoeffHight < 130 ? "1" :
                2 * Currents.MaxCurrentHightKZ / TT.transfCoeffHight < 250 ? "2,5" :
                2 * Currents.MaxCurrentHightKZ / TT.transfCoeffHight <= 500 ? "5" : "ПТН не выбран";

            NominalCurrentMediunPTN = TransformerData.type == TransformerData.TypeTransformer.Double || bmrz == BMRZ.Second ?
                " " : 2 * Currents.MaxCurrentMildleKZ / TT.transfCoeffMedium < 65 ? "0,5" :
                2 * Currents.MaxCurrentMildleKZ / TT.transfCoeffMedium < 130 ? "1" :
                2 * Currents.MaxCurrentMildleKZ / TT.transfCoeffMedium < 250 ? "2,5" :
                2 * Currents.MaxCurrentMildleKZ / TT.transfCoeffMedium <= 500 ? "5" : "ПТН не выбран";

            NominalCurrentLowerPTN = 2 * Currents.MaxCurrentLowerKZ / TT.transfCoeffLower < 65 ?
                "0,5" : 2 * Currents.MaxCurrentLowerKZ / TT.transfCoeffLower < 130 ? "1" :
                2 * Currents.MaxCurrentLowerKZ / TT.transfCoeffLower < 250 ? "2,5" :
                2 * Currents.MaxCurrentLowerKZ / TT.transfCoeffLower <= 500 ? "5" : "ПТН не выбран";

            #endregion

            #region ДТО

            MaximumUnbalanceCurrent = GetMaximumUnbalanceCurrent(); // отстройка от максимального тока небаланса

            DTOTriggerSetpoint = GetDTOTriggerSetpoint(); // уставка срабатывания ДТО

            #endregion

            #region Грубый огран ДЗТ

            Rought_InitialCurrent = GetRought_InitialCurrent(); // начальный ток срабатывания ДЗТ

            Rought_InitialCurrent_1_5 = GetRought_InitialCurrent_1_5(); // ток срабатывания ДЗТ при токе торможения

            Rought_SecondDecelerationCoefficient = GetRought_SecondDecelerationCoefficient(); // коэффициент торможения второго участка ДЗТ

            Rought_MaxiBrakingCurrent = GetRought_MaxiBrakingCurrent(); // ток торможения при максимальном токе КЗ

            Rought_ThirdDecelerationCoefficient = GetRought_ThirdDecelerationCoefficient(); // коэффициент торможения третьего участка ДЗТ

            #endregion

            #region Чувствительный огран ДЗТ

            Sensitive_InitialCurrent = GetSensitive_InitialCurrent(); // начальный ток срабатывания ДЗТ

            Sensitive_InitialCurrent_1_5 = GetSensitive_InitialCurrent_1_5(); // ток срабатывания ДЗТ при токе торможения 1,5 Iном

            Sensitive_SecondDecelerationCoefficient = GetSensitive_SecondDecelerationCoefficient(); // коэффициент торможения второго участка ДЗТ

            Sensitive_MaxUnbalanceCurrent = GetSensitive_MaxUnbalanceCurrent(); // отстройка от максимального тока небаланса

            Sensitive_ThirdDecelerationCoefficient = GetSensitive_ThirdDecelerationCoefficient(); // коэффициент торжения третьего участка ДЗТ

            #endregion

            // Проверка Чусвтвительности ДЗТ
            SensitivityCoefficient = GetSensitivityCoefficient();

            // Сигнализация небаланса
            UnbalanceAlarmRate = GetUnbalanceAlarmRate();
        }
        public static double GetSensitivityCoefficient()
        {
            return Math.Round(Currents.MinCurrentOtherKZToHight * (1 - TT.Emin) / NominalCurrentHight / Rought_InitialCurrent
                , round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetUnbalanceAlarmRate()
        {
            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNHight - 1) / 2 * TransformerData.stepRPNHight / 100);

            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNMedium - 1) / 2 * TransformerData.stepRPNMedium / 100);

            double k3 = (int)Currents.tsn == 1 ? 0 :
                Currents.WorkCurrentTSN / NominalCurrentHight;

            return Math.Round((1.1 * (1 * 1 * TT.Erab_max + k1 * 1 + k2 + 0.05 + k3) * 1) / Rought_InitialCurrent, round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetSensitive_InitialCurrent()
        {
            double result1 = 0.3;
            double result2 = DZT.DZTSensitive;

            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                TransformerData.settingCountRPNHight < 7 ? 0.5 :
                Math.Max(0.05, 3 * TransformerData.stepRPNHight / 100);

            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0 :
                TransformerData.settingCountRPNMedium < 7 ? 0.05 :
                Math.Max(0.05, 3 * TransformerData.stepRPNMedium / 100);

            double result3 = Math.Round(1.5 * (1 * 1 * TT.E0_5 + k1 * 1 + k2 + 0.05) * 0.5,
                round, MidpointRounding.ToPositiveInfinity);

            double result4 = (int)Currents.tsn == 1 ? 0 :
                Math.Round(1.5 * Currents.MaxCurrentTSN / NominalCurrentHight,
                round, MidpointRounding.ToPositiveInfinity);

            return Math.Max(Math.Max(result1, result2), Math.Max(result3, result4));
        }
        public static double GetSensitive_InitialCurrent_1_5()
        {
            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                TransformerData.settingCountRPNHight < 7 ? 0.5 :
                Math.Max(0.05, 3 * TransformerData.stepRPNHight / 100);

            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0 :
                TransformerData.settingCountRPNMedium < 7 ? 0.05 :
                Math.Max(0.05, 3 * TransformerData.stepRPNMedium / 100);

            return Math.Round(1.2 * (2 * 1 * TT.E1_5 + k1 * 1 + k2 * 1 + 0.05) * 1.5,
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetSensitive_SecondDecelerationCoefficient()
        {
            return Math.Round(Math.Max(0.2, Sensitive_InitialCurrent_1_5 - Sensitive_InitialCurrent),
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetSensitive_MaxUnbalanceCurrent()
        {
            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                TransformerData.settingCountRPNHight < 7 ? 0.5 :
                Math.Max(0.05, 3 * TransformerData.stepRPNHight / 100);

            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0 :
                TransformerData.settingCountRPNMedium < 7 ? 0.05 :
                Math.Max(0.05, 3 * TransformerData.stepRPNMedium / 100);

            double k3 = (int)TransformerData.type == 1 ? Currents.MaxCurrentLowerKZ_ToHight :
                Math.Max(Currents.MaxCurrentLowerKZ_ToHight, Currents.MaxCurrentMildleKZ_ToHight);

            return Math.Round(1.2 * (2.5 * 1 * TT.Emax + k1 * 1 + k2 * 1 + 0.05) * k3 / NominalCurrentHight,
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetSensitive_ThirdDecelerationCoefficient()
        {
            return Math.Round((Sensitive_MaxUnbalanceCurrent - Sensitive_InitialCurrent_1_5) / (Rought_MaxiBrakingCurrent - 1.5),
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetRought_InitialCurrent() // 
        {
            double result1 = 0.3;
            double result2 = DZT.DZTRough;

            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNHight - 1) / 2 * TransformerData.stepRPNHight / 100);
            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNMedium - 1) / 2 * TransformerData.stepRPNMedium / 100);

            double result3 = Math.Round(1.5 * (1 * 1 * TT.E0_5 + k1 * 1 + k2 + 0.05) * 0.5,
                round, MidpointRounding.ToPositiveInfinity);

            double result4 = (int)Currents.tsn == 1 ? 0 :
                Math.Round(1.5 * Currents.MaxCurrentTSN / NominalCurrentHight,
                round, MidpointRounding.ToPositiveInfinity);

            return Math.Max(Math.Max(result1, result2), Math.Max(result3, result4));
        }
        public static double GetRought_InitialCurrent_1_5() // 
        {
            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNHight - 1) / 2 * TransformerData.stepRPNHight / 100);

            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0.05 :
                Math.Max(0.05, (TransformerData.settingCountRPNMedium - 1) / 2 * TransformerData.stepRPNMedium / 100);

            return Math.Round(1.2 * (2 * 1 * TT.E1_5 + k1 * 1 + k2 + 0.05) * 1.5,
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetRought_SecondDecelerationCoefficient() // 
        {
            return Math.Round(Math.Max(0.02, Rought_InitialCurrent_1_5 - Rought_InitialCurrent),
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetRought_MaxiBrakingCurrent() // 
        {
            double k1 = (int)TransformerData.type == 1 ? Currents.MaxCurrentLowerKZ_ToHight :
                Math.Max(Currents.MaxCurrentLowerKZ_ToHight, Currents.MaxCurrentMildleKZ_ToHight);

            return Math.Round(((1 - 2.5 * TT.Emax / 2) * k1) / NominalCurrentHight,
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetRought_ThirdDecelerationCoefficient() // 
        {
            return Math.Round((MaximumUnbalanceCurrent - Rought_InitialCurrent_1_5) / (Rought_MaxiBrakingCurrent - 1.5),
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetMaximumUnbalanceCurrent() // 
        {
            double k1 = TransformerData.settingCountRPNHight == 0 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNHight - 1) / 2 * TransformerData.stepRPNHight / 100);

            double k2 = TransformerData.settingCountRPNMedium == 0 || (int)TransformerData.type < 3 ? 0 :
                Math.Max(0.05, (TransformerData.settingCountRPNMedium - 1) / 2 * TransformerData.stepRPNMedium / 100);

            double k3 = (int)TransformerData.type == 1 ? Currents.MaxCurrentLowerKZ_ToHight :
                Math.Max(Currents.MaxCurrentMildleKZ_ToHight, Currents.MaxCurrentLowerKZ_ToHight);

            return Math.Round(1.2 * (2.5 * 1 * TT.Emax + k1 * 1 + k2 + 0.05) * k3 / NominalCurrentHight,
                round, MidpointRounding.ToPositiveInfinity);
        }
        public static double GetDTOTriggerSetpoint() // 
        {
            return Math.Max(MaximumUnbalanceCurrent, DTO.BTN);
        }

    }
}
