using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Program
{
    internal class Chart
    {
        internal Polyline Сhart
        {
            get
            {
                var points = new PointCollection();
                for (int i = 0; i < Time.Length; i++)
                {
                    points.Add(new Point(Time[i], Amperage[i]));
                }
                return new Polyline()
                {
                    Points = points,
                    Stroke = Colour,
                    StrokeThickness = 0.5,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeLineJoin = PenLineJoin.Miter,
                    Opacity = 0.75,
                };
            }
        }

        internal double[] Time;

        internal double[] Amperage;

        internal Brush Colour;
        public Chart(double[] times, double[] amperages, Brush brush)
        {
            for (int i = 0; i < times.Length; i++)
            {
                times[i] = times[i] * 10;
                amperages[i] = amperages[i] * 10;
            }
            Time = times;
            Amperage = amperages;
            Colour = brush;
        }

        internal static Canvas Build(Chart c1, Chart c2, Chart c3)
        {
            var canvas = new Canvas();

            canvas.Children.Add(c1.Сhart);
            canvas.Children.Add(c2.Сhart);
            canvas.Children.Add(c3.Сhart);

            canvas.Height = c1.Amperage[0] * 1.001;
            canvas.Width = c1.Time[1] * 1.001;
            canvas.Background = Brushes.Transparent;

            for (int i = 0; i < canvas.Height / 10; i++)
            {
                canvas.Children.Add(new Line()
                {
                    X1 = 0,
                    X2 = canvas.Width,
                    Y1 = i * 10,
                    Y2 = i * 10,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.1,
                });
            }

            for (int i = 0; i < canvas.Width/ 10; i++)
            {
                canvas.Children.Add(new Line()
                {
                    Y1 = 0,
                    Y2 = canvas.Height,
                    X1 = i * 10,
                    X2 = i * 10,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.1,
                });
            }
            return canvas;
        }
    }
}
