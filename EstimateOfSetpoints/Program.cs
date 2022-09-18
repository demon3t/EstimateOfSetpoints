using Calculation;
using Calculation.Interfaces;

Transformer transformer = new Transformer(40, 115, 38.5, 11, 19, 1.78, 5, 2.5);

CalculRelay calcul = new(transformer);


Console.WriteLine(calcul.nominalCurrentHight());
Console.WriteLine(calcul.nominalCurrentMedium());
Console.WriteLine(calcul.nominalCurrentLower());