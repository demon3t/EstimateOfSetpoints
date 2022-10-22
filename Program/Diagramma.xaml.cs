using ScottPlot;
using ScottPlot.Styles;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
namespace Program
{
    /// <summary>
    /// Логика взаимодействия для Diagramma.xaml
    /// </summary>
    public partial class Diagramma : Window
    {

        public Diagramma()
        {
            InitializeComponent();

            MyPlot.Plot.Title("Характеристика срабатывания защиты", size: 18);
            MyPlot.Plot.XLabel("Время, с");
            MyPlot.Plot.YLabel("Ток, А");

            MyStyle style = new MyStyle();
            MyPlot.Plot.Style(style);
            MyPlot.Refresh();
        }
        public void Drawn(Chart c1, Chart c2, Chart c3)
        {
            MyPlot.Plot.AddScatter(c3.Time, c3.Amperage, lineWidth: 2, markerSize: 7);
            MyPlot.Plot.AddScatter(c2.Time, c2.Amperage, lineWidth: 2, markerSize: 7);
            MyPlot.Plot.AddScatter(c1.Time, c1.Amperage, lineWidth: 2, markerSize: 7);
            MyPlot.Refresh();

        }

        private class MyStyle : IStyle
        {
            public Color FigureBackgroundColor => Color.FromArgb(240, 248, 255);

            public Color DataBackgroundColor => Color.White;

            public Color FrameColor => Color.Black;

            public Color GridLineColor => Color.FromArgb(224, 225, 225);

            public Color AxisLabelColor => Color.Black;

            public Color TitleFontColor => Color.Black;

            public Color TickLabelColor => Color.Black;

            public Color TickMajorColor => Color.Black;

            public Color TickMinorColor => Color.DarkGray;

            public string AxisLabelFontName => "AxisLabelFontName";

            public string TitleFontName => "TitleFontName";

            public string TickLabelFontName => "TickLabelFontName";
        }
    }
}
