namespace Program
{
    internal static class TransformerData
    {
        internal enum TypeTransformer
        {
            Double = 1,
            Split = 2,
            Triple = 3
        }
        internal static TypeTransformer type { get; set; } = TypeTransformer.Triple;

        internal static double nominalPower { get; set; } = 40;
        internal static double nominalHightVoltage { get; set; } = 115;
        internal static double nominalMediumVoltage { get; set; } = 38.5;
        internal static double nominalLowerVoltage { get; set; } = 11;

        internal static int settingCountRPNHight { get; set; } = 19;
        internal static double stepRPNHight { get; set; } = 1.78;

        internal static int settingCountRPNMedium { get; set; } = 5;
        internal static double stepRPNMedium { get; set; } = 2.5;
    }
}
