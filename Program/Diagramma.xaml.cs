using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
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

        private double H;
        private double W;



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
            Width = 50,
            Height = 30,
        };

        public Diagramma(Canvas canvass)
        {
            InitializeComponent();

            mainCanvas = canvass;
            grid.Children.Add(mainCanvas);

            mainCanvas.MouseMove += Grid_MouseMove;
            mainCanvas.MouseLeftButtonUp += Grid_MouseLeftButtonUp;
            mainCanvas.MouseLeftButtonDown += Grid_MouseLeftButtonDown;
        }


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            point1 = Mouse.GetPosition(mainCanvas);
            label.Visibility = Visibility.Visible;
            line.Visibility = Visibility.Collapsed;
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
            label.Content = $"{Math.Round(Math.Sqrt(Math.Pow(point1.X - Mouse.GetPosition(mainCanvas).X, 2) + Math.Pow(point1.Y - Mouse.GetPosition(mainCanvas).Y, 2)) / 10, 2)}";
            Canvas.SetLeft(label, Mouse.GetPosition(mainCanvas).X - 4.2);
            Canvas.SetTop(label, Mouse.GetPosition(mainCanvas).Y + 3);

            line.X2 = Mouse.GetPosition(mainCanvas).X;
            line.Y2 = Mouse.GetPosition(mainCanvas).Y;
        }

        public void Drawn()
        {
            mainCanvas.VerticalAlignment = VerticalAlignment.Bottom;
            mainCanvas.HorizontalAlignment = HorizontalAlignment.Left;

            ScaleTransform scaleTransform = new ScaleTransform();

            scaleTransform.CenterX = 0;
            scaleTransform.CenterY = 0;
            scaleTransform.ScaleX = grid.ActualWidth / mainCanvas.Width;
            scaleTransform.ScaleY = -grid.ActualHeight / mainCanvas.Height;

            mainCanvas.RenderTransform = scaleTransform;

            W = maingrig.ActualWidth;
            H = maingrig.ActualWidth;

            ScaleTransform scaleTransform1 = new ScaleTransform();
            scaleTransform1.CenterX = 0;
            scaleTransform1.CenterY = 0;
            scaleTransform1.ScaleX = 0.1 * grid.ActualWidth / label.ActualWidth;
            scaleTransform1.ScaleY = -0.1 * grid.ActualHeight / label.ActualHeight;
            line.StrokeThickness = ((Polyline)mainCanvas.Children[0]).StrokeThickness / 1.5;
            //label.RenderTransform = scaleTransform1;

            maingrig.Children.Add(label);
            mainCanvas.Children.Add(line);

            label.VerticalAlignment = VerticalAlignment.Bottom;
            label.HorizontalAlignment = HorizontalAlignment.Left;

            label.Margin = new Thickness(10, 10, 10, 10);

            window.SizeChanged += Ffr_SizeChanged;
        }

        private void Ffr_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ScaleTransform scaleTransform = new ScaleTransform();

            scaleTransform.CenterX = 0;
            scaleTransform.CenterY = 0;
            scaleTransform.ScaleX = grid.ActualWidth / mainCanvas.Width;
            scaleTransform.ScaleY = -grid.ActualHeight / mainCanvas.Height;

            mainCanvas.RenderTransform = scaleTransform;

            //ScaleTransform scaleTransform1 = new ScaleTransform();

            //scaleTransform1.CenterX = 0;
            //scaleTransform1.CenterY = 0;
            //scaleTransform1.ScaleX = 0.1 * grid.ActualWidth / label.ActualWidth;
            //scaleTransform1.ScaleY = -0.1 * grid.ActualHeight / label.ActualHeight;

            //label.RenderTransform = scaleTransform1;
        }
    }
}
