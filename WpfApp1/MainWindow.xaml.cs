using Calculation;
using HandyControl.Tools;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Transformer transformer = new Transformer()
        {
            type = Transformer.TypeTransformer.Double,
            nominalPower = 40,
            nominalHightVoltage = 115,
            nominalMediumVoltage = 38.5,
            nominalLowerVoltage = 11,
        };
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("ru");
        }

        #region TabControl #1
        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            transformer.type = Transformer.TypeTransformer.Double;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор";
        }
        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            transformer.type = Transformer.TypeTransformer.Split;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор с расщеплённой обмоткой стороны НН";
        }
        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            transformer.type = Transformer.TypeTransformer.Triple;
            SelectTypeTransformer.Content = "Трёххобмоточный трансформатор";
        }

        #endregion




        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || e.Text == "." || e.Text == ","))
            {
                e.Handled = true;
                return;
            }
            if ((e.Text == "." || e.Text == ",") && (((TextBox)sender).Text.Contains(",") || ((TextBox)sender).Text.Contains(".")))
            {
                e.Handled = true;
                return;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
