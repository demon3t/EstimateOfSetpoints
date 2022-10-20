using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Program
{
    /// <summary>
    /// Логика взаимодействия для Diagramma.xaml
    /// </summary>
    public partial class Diagramma : Window
    {
        public Canvas mainCanvas;
        public Canvas CanvasLeft;
        public Canvas CanvasBottom;

        private Point point1 = new Point();

        private System.Windows.Controls.Label label = new System.Windows.Controls.Label()
        {
            FontSize = 18,
            Visibility = Visibility.Collapsed,
        };

        private Line line = new Line()
        {
            Stroke = Brushes.Black,
            Opacity = 0.75,
            Visibility = Visibility.Collapsed,
            StrokeStartLineCap = PenLineCap.Round,
            StrokeEndLineCap = PenLineCap.Round,
            StrokeLineJoin = PenLineJoin.Miter,
            StrokeThickness = 1,
            StrokeDashCap = PenLineCap.Round,
            StrokeDashArray = new DoubleCollection(new double[] { 10, 5 }),
        };

        public Diagramma(Canvas canvass)
        {
            InitializeComponent();

            mainCanvas = canvass;
            ForCanvas.Children.Add(mainCanvas);

            ForCanvas.MouseMove += Grid_MouseMove;
            ForCanvas.MouseLeftButtonUp += Grid_MouseLeftButtonUp;
            ForCanvas.MouseLeftButtonDown += Grid_MouseLeftButtonDown;
        }


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            point1 = Mouse.GetPosition(mainCanvas);
            label.Visibility = Visibility.Visible;
            line.Visibility = Visibility.Visible;
            line.X1 = Mouse.GetPosition(mainCanvas).X;
            line.Y1 = Mouse.GetPosition(mainCanvas).Y;
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            label.Visibility = Visibility.Collapsed;
            line.Visibility = Visibility.Collapsed;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            double linage = Math.Round(Math.Sqrt(
                Math.Pow(point1.X - Mouse.GetPosition(mainCanvas).X, 2) * Chart.chart.Time[0] / 1080 +
                Math.Pow(point1.Y - Mouse.GetPosition(mainCanvas).Y, 2) * Chart.chart.Amperage[0] / 720), 2);

            label.Content = $"{linage}";

            Canvas.SetLeft(label, Mouse.GetPosition(mainCanvas).X - 55);
            Canvas.SetTop(label, Mouse.GetPosition(mainCanvas).Y + 40);

            line.X2 = Mouse.GetPosition(mainCanvas).X;
            line.Y2 = Mouse.GetPosition(mainCanvas).Y;
        }

        public void Drawn()
        {
            mainCanvas.VerticalAlignment = VerticalAlignment.Bottom;
            mainCanvas.HorizontalAlignment = HorizontalAlignment.Right;

            mainCanvas.RenderTransform = new ScaleTransform()
            {
                ScaleX = 1,
                ScaleY = -1,
                CenterX = 1080 / 2,
                CenterY = 720 / 2
            };

            label.RenderTransform = new ScaleTransform()
            {
                ScaleX = 1,
                ScaleY = -1,
                CenterX = 0,
                CenterY = 0
            };

            mainCanvas.Children.Add(label);
            mainCanvas.Children.Add(line);
        }

        private void ForCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {


        }
    }
}
