namespace Program
{
    internal static class Currents
    {
        internal enum TSN
        {
            No = 1,
            Yes = 2
        }

        internal static TSN tsn = TSN.No;

        internal static double MaxCurrentHightKZ { get; set; } = 4427;
        internal static double MaxCurrentMildleKZ { get; set; } = 4514;
        internal static double MaxCurrentLowerKZ { get; set; } = 14177;
        internal static double MaxCurrentHightKZ_ToHight { get; set; } = 4427;
        internal static double MaxCurrentMildleKZ_ToHight { get; set; } = 1729;
        internal static double MaxCurrentLowerKZ_ToHight { get; set; } = 1541;

        internal static double MinCurrentOtherKZToHight { get; set; } = 392;

        internal static double MaxCurrentTSN { get; set; } = 0;
        internal static double WorkCurrentTSN { get; set; } = 0;
    }
}
