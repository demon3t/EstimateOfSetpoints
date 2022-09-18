using Calculation;
using Calculation.Interfaces;

Transformer transformer = new Transformer(40, 115, 38.5, 11, 19, 1.78, 5, 2.5 , Transformer.TypeTransformer.Triple);

CalculRelay calcul = new(transformer, CalculRelay.CalculPower.Full, CalculRelay.TSN.No, CalculRelay.BMRZ.First);

IDZT dZT = calcul;

// Расчёт минимальных токов сторон
Console.WriteLine();
Console.WriteLine("Расчёт минимальных токов сторон");
Console.WriteLine(calcul.NominalCurrentHight());
Console.WriteLine(calcul.NominalCurrentMedium());
Console.WriteLine(calcul.NominalCurrentLower());

//Проверка ПТН в нагрузочном режиме
Console.WriteLine();
Console.WriteLine("Проверка ПТН в нагрузочном режиме");
Console.WriteLine(calcul.VerifyPTNHigth());
Console.WriteLine(calcul.VerifyPTNMedium());
Console.WriteLine(calcul.VerifyPTNLower());

//Расчёт уставок ДТО
Console.WriteLine();
Console.WriteLine("Расчёт уставок ДТО");
Console.WriteLine(calcul.MaximumUnbalanceCurrent());
Console.WriteLine(calcul.DTOTriggerSetpoint());

// "Грубый" орган ДЗТ
Console.WriteLine();
Console.WriteLine("\"Грубый орган ДЗТ\"");
Console.WriteLine(dZT.Rought_InitialCurrent());
Console.WriteLine(dZT.Rought_InitialCurrent_1_5());
Console.WriteLine(dZT.Rought_SecondDecelerationCoefficient());
Console.WriteLine(dZT.Rought_MaxiBrakingCurrent());
Console.WriteLine(dZT.Rought_ThirdDecelerationCoefficient());

// "Чувствительный" орган ДЗТ
Console.WriteLine();
Console.WriteLine("\"Чувствительный\" орган ДЗТ");
Console.WriteLine(dZT.Sensitive_InitialCurrent());
Console.WriteLine(dZT.Sensitive_InitialCurrent_1_5());
Console.WriteLine(dZT.Sensitive_SecondDecelerationCoefficient());
Console.WriteLine(dZT.Sensitive_MaxUnbalanceCurrent());
Console.WriteLine(dZT.Sensitive_ThirdDecelerationCoefficient());



