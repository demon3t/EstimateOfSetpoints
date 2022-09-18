using Calculation;
using Calculation.Interfaces;

Transformer transformer = new Transformer(40, 115, 38.5, 11, 19, 1.78, 5, 2.5 , Transformer.TypeTransformer.Triple);


CalculRelay calcul = new(transformer, CalculRelay.CalculPower.Full);


Console.WriteLine(calcul.NominalCurrentHight());
Console.WriteLine(calcul.NominalCurrentMedium());
Console.WriteLine(calcul.NominalCurrentLower());

Console.WriteLine(calcul.VerifyPTNHigth());
Console.WriteLine(calcul.VerifyPTNMedium());
Console.WriteLine(calcul.VerifyPTNLower());

Console.WriteLine(calcul.MaximumUnbalanceCurrent());
Console.WriteLine(calcul.DTOTriggerSetpoint());

