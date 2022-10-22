using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Program
{
    public class Chart
    {
        internal double[] Time;

        internal double[] Amperage;

        internal Brush Colour;
        public Chart(double[] times, double[] amperages, Brush brush)
        {
            Time = times;
            Amperage = amperages;
            Colour = brush;
        }
    }
}
