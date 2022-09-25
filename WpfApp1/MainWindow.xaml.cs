using Calculation;
using Calculation.Interfaces;
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
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("ru");
        }

        #region TabControl #1
        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            Transformer.type = Transformer.TypeTransformer.Double;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор";
            settingCountRPNMedium.IsEnabled = false;
            stepRPNMedium.IsEnabled = false;
        }
        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            Transformer.type = Transformer.TypeTransformer.Split;
            SelectTypeTransformer.Content = "Двухобмоточный трансформатор с расщеплённой обмоткой стороны НН";
            settingCountRPNMedium.IsEnabled = false;
            stepRPNMedium.IsEnabled = false;
        }
        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            Transformer.type = Transformer.TypeTransformer.Triple;
            SelectTypeTransformer.Content = "Трёхобмоточный трансформатор";
            settingCountRPNMedium.IsEnabled = true;
            stepRPNMedium.IsEnabled = true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double result))
                return;

            switch (((TextBox)sender).Name)
            {
                case "nominalPower":
                    {
                        Transformer.nominalPower = result;
                        break;
                    }
                case "nominalHightVoltage":
                    {
                        Transformer.nominalHightVoltage = result;
                        break;
                    }
                case "nominalMediumVoltage":
                    {
                        Transformer.nominalMediumVoltage = result;
                        break;
                    }
                case "nominalLowerVoltage":
                    {
                        Transformer.nominalLowerVoltage = result;
                        break;
                    }
                case "settingCountRPNHight":
                    {
                        Transformer.settingCountRPNHight = (int)result;
                        break;
                    }
                case "stepRPNHight":
                    {
                        Transformer.stepRPNHight = result;
                        break;
                    }
                case "settingCountRPNMedium":
                    {
                        Transformer.settingCountRPNMedium = (int)result;
                        break;
                    }
                case "stepRPNMedium":
                    {
                        Transformer.stepRPNMedium = result;
                        break;
                    }
            }
        }

        #endregion




        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || e.Text == "." || e.Text == ","))
            {
                e.Handled = true;
                return;
            }

            TextBox textBox = sender as TextBox;
            if (textBox != null)
                if ((e.Text == "." || e.Text == ",") && (textBox.Text.Contains(",") || textBox.Text.Contains(".")))
                {
                    e.Handled = true;
                    return;
                }
        }
        private void TextBox_PreviewTextInputNoDouble(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
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

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }
    }
}
